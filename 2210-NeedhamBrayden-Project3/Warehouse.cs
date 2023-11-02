using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Warehouse.cs                                            *   
*--------------------------------------------------------------------*
* Author’s name and email: Brayden Needham | needhambg@etsu.edu      *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    internal class Warehouse
    {
        public List<Dock> Docks { get; set; }
        Queue<Truck> Entrance { get; set; }

        public Warehouse() { }
    }
}
