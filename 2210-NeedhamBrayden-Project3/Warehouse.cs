﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Warehouse.cs                                            *   
*--------------------------------------------------------------------*
* Author’s names: Brayden Needham, Jacob Sullins, and Terry McCulley *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    internal class Warehouse
    {
        public List<Dock> Docks { get; set; }
        public Queue<Truck> Entrance { get; set; }


        public Warehouse() 
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
        }

        public void Run()
        {
            Random rnd = new Random();
            Truck truck = new Truck();
            Dock dock = new Dock();
            List<Crate> list = new();

            //we'll start out with 100 crates max for now, i'll email gillenwater to get a max 
            Crate[] crates = new Crate[rnd.Next(1, 100)]; 
            for (int i = 0; i < crates.Length; i++)
            {
                crates[i] = new Crate($"C{i}");
            }

            foreach (Crate crate in crates)
            {
                truck.Load(crate);
            }

            Console.WriteLine(truck.Driver + "\t" + truck.DeliveryCompany);

            for (int i = 0; i < crates.Length; i++)
            {
                //Crate data = truck.Unload();
                //Console.WriteLine(data.IdNumber + "\t"+ "$" + data.Price);
                //I'll find out how to implement the time increments soon, just sending this in to save it
            }
        }
        //In here we need to Assign Trucks in the entrance to each dock as they become available
        public void AssignTruckToDock()
        {
            bool emptyDockFound = false;
            int currentDock = 0;
            while (emptyDockFound != true) 
            {
                if (Docks[currentDock].CurrentTruck == null)
                {
                    emptyDockFound = true;
                    Docks[currentDock].NewTruckIn(Entrance.Dequeue());
                }
            }
        }
        /// <summary>
        /// This method brings trucks that are on the road and brings them to the entrance of the warehouse so that they may
        /// be sorted to each dock
        /// </summary>
        /// <param name="trucksFromRoad"></param>
        public void AddToEntrance(Queue<Truck> trucksFromRoad)
        {
            for(int i = 0; i < trucksFromRoad.Count;i++)
            {
                Entrance.Enqueue(trucksFromRoad.Dequeue());
            }
        }
    }

    
}
