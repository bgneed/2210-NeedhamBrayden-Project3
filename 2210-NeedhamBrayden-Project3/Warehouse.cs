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
* Authors' Names: Brayden Needham, Jacob Sullivan, and Terry McCulley*
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
    }
}
