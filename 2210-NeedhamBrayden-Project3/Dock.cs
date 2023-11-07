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
* Authors' Names: Brayden Needham, Jacob Sullivan, and Terry McCulley*
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public class Dock
    {
        public string IdNumber {  get; set; }
        public Queue<Truck> Line { get; set; }
        public Truck CurrentTruck { get; set; }
        public double TotalSales { get; set; }
        public int TotalCrates { get; set; }
        public List<Crate> Crates { get; set; }
        public Crate CurrentCrate { get; set; }
        public int TotalTrucks { get; set; }
        public int TotalTimeInUse { get; set; }
        public int TimeNotInUse { get; set; }
        public Dock()
        {
            Line = new Queue<Truck>();
            CurrentTruck = new Truck();
            CurrentCrate = new Crate();
            TotalCrates = 0;
            TotalTrucks = 0;
            TimeNotInUse = 0;
            TotalSales = 0;
        }

        public Dock()
        {
            IdNumber = "0";
            Line = new Queue<Truck>();
            TotalSales = 0;
            TotalCrates = 0;
            TimeNotInUse = 0;
            TotalTrucks = 0;
            TotalTimeInUse = 0;
        }

        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
        }
        public Truck SendOff()
        {
            return Line.Dequeue();
        }
        public Crate RemoveCrate()
        {
            CurrentCrate = new Crate(CurrentTruck.Unload());
            Crates.Add(CurrentCrate);
            return CurrentCrate;
        }
    }
}
