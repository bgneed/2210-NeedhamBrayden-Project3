using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Dock.cs                                                 *   
*--------------------------------------------------------------------*
* Author’s names: Brayden Needham, Jacob Sullins, and Terry McCulley *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public class Dock
    {
        public string IdNumber { get; set; }
        //public Queue<Truck> Line { get; set; }
        public Truck? CurrentTruck { get; private set; }
        public double TotalSales { get; set; }
        public int TotalCrates { get; set; }
        public List<Crate> Crates { get; set; }
        public Crate CurrentCrate { get; set; }
        public int TotalTrucks { get; set; }
        public bool IsOpen { get; private set; }
        public uint TotalTimeInUse { get; set; }
        public uint TimeNotInUse { get; set; }
        public Dock()
        {
            IdNumber = "C0";
            //Line = new Queue<Truck>();
            CurrentTruck = new Truck();
            CurrentCrate = new Crate();
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeNotInUse = 0;
            TotalSales = 0;
            TotalTimeInUse = 0;
        }
        public Dock(string idNum)
        {
            IdNumber = idNum;
            //Line = new Queue<Truck>();
            CurrentTruck = new Truck();
            CurrentCrate = new Crate();
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeNotInUse = 0;
            TotalSales = 0;
            TotalTimeInUse = 0;
        }
        //Remove Crates from Current Truck : One per time increment
        public void RemoveCrate()
        {
            uint unloadTime = 0;
            CurrentCrate = CurrentTruck.Unload(unloadTime);
            TotalCrates++;
            TotalSales += CurrentCrate.Price;
            TotalTimeInUse += unloadTime;
        }
        //Change trucks that are in the dock at the time: Remove Crate and Send Truck off in one increment
        //then on the next increment Bring new truck in and remove a crate 
        public void SendOff()
        {
            //This should only happen when there is one crate left in the truck
            RemoveCrate();
            CurrentTruck = null;
        }
        public void NewTruckIn(Truck newTruck)
        {
            CurrentTruck = newTruck;
            RemoveCrate();
        }
        public void UpdateDock(Queue<Truck> Entrance, uint time)
        {
            //Check if truck in this dock == null
            if (CurrentTruck != null)
            {
                //if not null then are there more than one crates to unload
                if (CurrentTruck.Trailer.Count == 1)
                {
                    SendOff();
                }
                //if no more than one crate then run send off. if more than one then run unload
                else if (CurrentTruck.Trailer.Count > 1)
                {
                    CurrentTruck.Unload(time); //Could be problems with this so please watch for them
                }
                else
                //This should never happen as there should never be an instance in which CurrentTruck.Trailer.Count > 1 and truck != null
                {
                    throw new Exception("Truck is not null and has no crates to be unloaded this is a problem");
                }
            }
            else
            {
                //if truck in dock == null then run new truck in if dock is open
            }


        }









        //public Truck SendOff()
        //{
        //    int count = CurrentTruck.Trailer.Count;

        //    for (int i = 0; i < count; i++)
        //    {
        //        CurrentTruck.Unload(out uint unloadTime);
        //        TotalCrates++;
        //        TotalTimeInUse += unloadTime;
        //    }

        //    return CurrentTruck;
        //}
        //public Crate RemoveCrate()
        //{
        //    uint removalTime;
        //    CurrentCrate = new Crate(CurrentTruck.Unload(out removalTime));
        //    CurrentCrate.TimeWhenUnloaded = removalTime;
        //    Crates.Add(CurrentCrate);
        //    return CurrentCrate;
        //}
    }
}
