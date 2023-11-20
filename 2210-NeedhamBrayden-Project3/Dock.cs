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
        public Truck? CurrentTruck { get; private set; }
        public double TotalSales { get; set; }
        public int TotalCrates { get; set; }
        public List<Crate> Crates { get; set; }
        public Crate CurrentCrate { get; set; }
        public int TotalTrucks { get; set; }
        public bool OpenStatus { get; set; }
        public uint TotalTimeInUse { get; set; }
        public uint TimeNotInUse { get; set; }
        public int OperatingCost { get; set; }

        public Dock()
        {
            IdNumber = "00";
            CurrentTruck = null;
            CurrentCrate = null;
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeNotInUse = 0;
            TotalSales = 0;
            TotalTimeInUse = 0;
        }
        public Dock(string idNum)
        {
            IdNumber = idNum;
            CurrentTruck = null;
            CurrentCrate = null;
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeNotInUse = 0;
            TotalSales = 0;
            TotalTimeInUse = 0;
        }
        //Remove Crates from Current Truck : One per time increment
        /// <summary>
        /// A method that removes the next crate from the trailer of the truck. 
        /// Updates the total # of crates unloaded into the dock, the total sales (the price of each crate combined),
        /// as well as the total time in use of the dock.
        /// </summary>
        public void RemoveCrate(uint unloadTime)
        {
            //uint unloadTime = 0;    
            CurrentCrate = CurrentTruck.Unload(unloadTime); //There will be a problem here
            TotalCrates++;
            TotalSales += CurrentCrate.Price;
        }
        //Change trucks that are in the dock at the time: Remove Crate and Send Truck off in one increment
        //then on the next increment Bring new truck in and remove a crate 
        /// <summary>
        /// A private method that will send the current truck off so that a new one can come in and be unloaded. 
        /// The method unloads the final crate and sends the truck off in one time increment. 
        /// </summary>
        private void SendOff(uint time)
        {
            //This should only happen when there is one crate left in the truck
            RemoveCrate(time);
            CurrentTruck = null;
        }
        /// <summary>
        /// A method for bringing a new truck into the dock. 
        /// In this method we bring in a new truck by copying the reference to the truck that is passed in, then unload one crate
        /// from the truck, all in one time increment. 
        /// </summary>
        /// <param name="newTruck"></param>
        public void NewTruckIn(Truck newTruck,uint time)
        {
            CurrentTruck = newTruck;
            RemoveCrate(time);
        }
        /// <summary>
        /// ---------TLDR; This method updates the status of the truck by either removing a crate and sending the truck off, remvoing a crate
        /// and then returning, or bringing in a new truck.------------
        /// If the truck is not null, then it is checked for how many crates it has. There is an exception that can be thrown if 
        /// there is a truck that is not null, and has zero crates, this is an illegal case thus, the exception is thrown. 
        /// If the truck is not null and has exactly one crate, the send off method is run, else if there is mor ethan one then it
        /// will simply unload a crate and return.
        /// If there is no truck in the dock then it will bring in the next truck
        /// 
        /// Method returns 1 if a crate was unloaded and there was no change in the CurrentTruck,
        ///  returns 2 if a crate was unloaded and a truck sent off, and
        ///  returns 3 if a new truck is taken in
        /// </summary>
        /// <param name="Entrance"></param>
        /// <param name="time"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateDock(Queue<Truck> Entrance, uint time,out int whatEventOcurred)
        {
            //Check if truck in this dock == null
            if (CurrentTruck != null)
            {
                TotalTimeInUse += 10;

                //if not null then are there more than one crates to unload
                if (CurrentTruck.Trailer.Count == 1)
                {
                    SendOff(time);
                    whatEventOcurred = 2;
                    return;
                }
                //if no more than one crate then run send off. if more than one then run unload
                else if (CurrentTruck.Trailer.Count > 1)
                {
                    RemoveCrate(time);
                    whatEventOcurred= 1;
                    return;
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
                if (Entrance.Count > 0)
                {
                    NewTruckIn(Entrance.Dequeue(), time);
                    whatEventOcurred = 3;
                }
                else
                {

                    whatEventOcurred = 4;
                    return;
                }
            }
        }
    }
}
