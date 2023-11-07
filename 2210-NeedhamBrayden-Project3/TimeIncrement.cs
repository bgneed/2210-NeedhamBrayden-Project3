using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-001-NeedhamBrayden-Project3                     *
* File name: TimeIncrement.cs                                        *   
*--------------------------------------------------------------------*
* Authors' Names: Brayden Needham, Jacob Sullivan, and Terry McCulley*
* Course-Section: 2210-001                                           *   
* Creation Date: 11/7/2023                                           *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public static class TimeIncrement
    {
        private static int Increment;

        static TimeIncrement()
        {
            Increment = 0;
        }

        public static void AddIncrement()
        {
            Increment++;
        }

        public static int GetIncrement()
        {
            return Increment;
        }
    }
}
