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
        /// <summary>
        /// Simply a method to add 10 to the time increment
        /// </summary>
        public static void AddIncrement()
        {
            Increment += 10;
        }
        /// <summary>
        /// A method that returns a string based on the time of day and will help generate different amount of trucks based on the time 
        /// of day. Returns : Early Morning, Morning, Midday, Pre Noon, Noon, After Noon, Evening, Late Evening, End of Day, or 
        /// throws an Exception that says Invalid Time Increment (Should Never Actually Return This)
        /// </summary>
        /// <returns></returns>
        public static string GetIncrement()
        {
            if(Increment <= 60)
            {
                return "Early Morning";
            }
            else if(Increment >= 70 &&  Increment <= 120)
            {
                return "Morning";
            }
            else if(Increment >= 130 && Increment <= 190)
            {
                return "Midday";
            }
            else if( Increment >= 200 && Increment <= 260)
            {
                return "Pre Noon";
            }
            else if(Increment >= 270 && Increment <= 320)
            {
                return "Noon";
            }
            else if (Increment >= 330 && Increment <= 390)
            {
                return "After Noon";
            }
            else if (Increment >= 400 && Increment <= 460)
            {
                return "Evening";
            }
            else if (Increment >= 470 && Increment <= 520)
            {
                return "Late Evening";
            }
            else if (Increment >= 530)
            {
                return "End of Day";
            }
            else 
            {
                throw new Exception("Invalid Time Increment");
            }
        }
    }
}
