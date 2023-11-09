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
* Authors' Names: Brayden Needham, Jacob Sullivan, and Terry McCulley*
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
        //Also crate creation will take place inside of the truck creation and a random Id number will be given to each crate that will then
        //be tracked here to make sure each crate is unique and has a different number than every other crate
        public Road()
        {
            WaitLine = new Queue<Truck>();
        }
        public void AddToWaitLine()
        {
            //This will add trucks to the waitline based on the time of day
            if(TimeIncrement.GetIncrement() == "Early Morning")
            {

            }
            else if (TimeIncrement.GetIncrement() == "Morning")
            {

            }
            else if (TimeIncrement.GetIncrement() == "Midday")
            {

            }
            else if (TimeIncrement.GetIncrement() == "Pre Noon")
            {

            }
            else if (TimeIncrement.GetIncrement() == "Noon")
            {
                //Busiest time of day
            }
            else if (TimeIncrement.GetIncrement() == "After Noon")
            {

            }
            else if (TimeIncrement.GetIncrement() == "Evening")
            {

            }
            else if (TimeIncrement.GetIncrement() == "End of Day")
            {

            }
        }
        //Earlier time increments will be slower with truck creation. Mid time increments will be a lot more full
        //late time increments will be slower as well
    }
}
