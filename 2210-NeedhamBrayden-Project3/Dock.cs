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
* Author’s name and email: Brayden Needham | needhambg@etsu.edu      *
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
        public double TotalSales { get; set; }
        public int TotalCrates { get; set; }
        public int TotalTrucks { get; set; }
        public int TotalTimeInUse { get; set; }
        public int TimeNotInUse { get; set; }

        public void JoinLine(Truck truck)
        {
            Line.Enqueue(truck);
        }
        public Truck SendOff()
        {
            return Line.Dequeue();
        }
    }
}
