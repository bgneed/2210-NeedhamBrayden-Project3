using System;
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
            for(int i = 0; i < numOfDocks; i++) 
            {
                Dock newDock = new Dock("0"+ i+1);
                newDock.OpenStatus = true;
                Warehouse.Docks.Add(newDock);
            }
            AddToWaitLine();
            SendToEntrance();
            foreach(Truck truck in Warehouse.Entrance)
            {
                Warehouse.AssignTruckToDock(Time);
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
                Warehouse.AssignTruckToDock(Time);
            }
        }
        public void AddToWaitLine()
        {
            //This will add trucks to the waitline based on the time of day
            if (GetTimeFrame() == "Early Morning")
            {
                Likelihood = 10;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Morning")
            {
                Likelihood = 6;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Midday")
            {
                Likelihood = 10;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Pre Noon")
            {
                Likelihood = 12;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Noon")
            {
                Likelihood = 20;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "After Noon")
            {
                Likelihood = 8;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "Evening")
            {
                Likelihood = 6;
                QueueTrucks();
            }
            else if (GetTimeFrame() == "End of Day")
            {
                Likelihood = 0;
                QueueTrucks();
            }
        }
        //Earlier time increments will be slower with truck creation. Mid time increments will be a lot more full
        //late time increments will be slower as well

        /// <summary>
        /// This method will generate a number of trucks based on the likelihood value contained within this class
        /// it will also use the time to pass into the truck constructor, and then it will enqueue each truck into the waitline of the 
        /// road class. Uses a for loop to go through the amount of trucks needed to be generated
        /// </summary>
        public void QueueTrucks()
        {
            Random randy = new Random();

            int chance = randy.Next(0, Likelihood);
            for (int i = 0; i < chance; i++)
            {
                Truck truck = new(Time);
                WaitLine.Enqueue(truck);
            }
        }
        /// <summary>
        /// This method will use the Time property of the road class to get the time of day that the simulation is currently in.
        /// Returns a string based on the time of day and uses if statments to check what the time of day is
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
            else if (Time > 480)
            {
                return "End of Day";
            }
            else
            {
                throw new Exception("Invalid Time Increment");
            }
        }
        /// <summary>
        /// This method increments the time by one and adds it to the Time property
        /// </summary>
        public void IncrementTime()
        {
            Time += 10;
        }
        /// <summary>
        /// This method resets the time property back to 0
        /// </summary>
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
