﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Road.cs                                                 *   
*--------------------------------------------------------------------*
* Author’s names: Brayden Needham, Jacob Sullins, and Terry McCulley *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public class Road
    {
        //Truck creation will take place here and will then feed into the warehouses Queue at the entrance
        public Queue<Truck> WaitLine;

        private int Likelihood;

        public Warehouse Warehouse;

        public uint Time;
        //Also crate creation will take place inside of the truck creation and a random Id number will be given to each crate that will then
        //be tracked here to make sure each crate is unique and has a different number than every other crate
        public Road(Warehouse warehouse)
        {
            WaitLine = new Queue<Truck>();
            Likelihood = 0;
            Time = 0;
            Warehouse = warehouse;
        }
        public void Initialize(int numOfDocks)
        {
            Warehouse.Docks  = new List<Dock>();
            for(int i = 0; i <= numOfDocks; i++) 
            {
                Dock newDock = new Dock("0"+ i);
                newDock.OpenStatus = true;
                Warehouse.Docks.Add(newDock);
            }
            AddToWaitLine();
            SendToEntrance();
            foreach(Truck truck in Warehouse.Entrance)
            {
                Warehouse.AssignTruckToDock();
            }
        }
        #region Jacob Code
        public void SendToEntrance()
        {
            for(int i = 0; i < WaitLine.Count; i++)
            {
                Warehouse.Entrance.Enqueue(WaitLine.Dequeue());
            }
            for(int i = 0; i < Warehouse.Entrance.Count; i++)
            {
                Warehouse.AssignTruckToDock();
            }
        }
        public void AddToWaitLine()
        {
            //This will add trucks to the waitline based on the time of day
            if (GetTimeFrame() == "Early Morning")
            {
                Likelihood = 5;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Morning")
            {
                Likelihood = 3;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Midday")
            {
                Likelihood = 5;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Pre Noon")
            {
                Likelihood = 6;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Noon")
            {
                Likelihood = 10;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "After Noon")
            {
                Likelihood = 4;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Evening")
            {
                Likelihood = 3;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "End of Day")
            {
                Likelihood = 2;
                QueueTrucks();
            }
        }
        //Earlier time increments will be slower with truck creation. Mid time increments will be a lot more full
        //late time increments will be slower as well

        public void QueueTrucks()
        {
            for (int i = 0; i <= Likelihood; i++)
            {
                Truck truck = new(Time);
                WaitLine.Enqueue(truck);
            }
        }

        public string GetTimeFrame()
        {
            if (Time <= 60)
            {
                return "Early Morning";
            }
            else if (Time >= 70 && Time <= 120)
            {
                return "Morning";
            }
            else if (Time >= 130 && Time <= 190)
            {
                return "Midday";
            }
            else if (Time >= 200 && Time <= 260)
            {
                return "Pre Noon";
            }
            else if (Time >= 270 && Time <= 320)
            {
                return "Noon";
            }
            else if (Time >= 330 && Time <= 390)
            {
                return "After Noon";
            }
            else if (Time >= 400 && Time <= 480)
            {
                return "Evening";
            }
            else if (Time >= 480)
            {
                return "End of Day";
            }
            else
            {
                throw new Exception("Invalid Time Increment");
            }
        }

        public void IncrementTime()
        {
            Time += 10;
        }

        public void ResetTime()
        {
            Time = 0;
        }

        public void UpdateTimeViaDock()
        {
            int i;
            foreach (Dock d in Warehouse.Docks)
            {
                d.UpdateDock(Warehouse.Entrance, Time, out i);
            }
            IncrementTime();
        }
        #endregion
    }
}
