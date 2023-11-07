using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Crate.cs                                                *   
*--------------------------------------------------------------------*
* Authors' Names: Brayden Needham, Jacob Sullivan, and Terry McCulley*
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public class Crate : IComparable<Crate>
    {
        public string IdNumber {  get; set; }
        public double Price { get; set; }  
        public uint TimeWhenUnloaded { get; set; }

        public Crate() 
        {
            IdNumber = "0";
            Price = 0;
        }
        //Doing this so that I can keep track of the IdNumbers and make sure each crate has a unique one
        public Crate(string idNumber)
        {
            IdNumber = idNumber;
            Random random = new Random();
            double price = random.Next(50, 501);
            Price = price;
        }
        public Crate(string idNumber, uint time)
        {
            IdNumber = idNumber;
            Random random = new Random();
            double price = random.Next(50, 501);
            SetTime(time);
            Price = price;
        }
        public Crate(Crate copyCrate)
        {
            IdNumber = copyCrate.IdNumber;
            Price = copyCrate.Price;
        }
        /// <summary>
        /// A method that simply returns the time when the crate was unloaded
        /// </summary>
        /// <returns></returns>
        public uint GetTime()
        {
            return TimeWhenUnloaded;
        }
        /// <summary>
        /// A method that sets the unload time to the time that is input to the method
        /// </summary>
        /// <param name="time"></param>
        public void SetTime(uint time)
        {
            TimeWhenUnloaded = time;
        }
        /// <summary>
        /// A method to compare two crates to each other. 
        /// Returns 0 if equal, -1 if not.
        /// </summary>
        /// <param name="crate"></param>
        /// <returns></returns>
        public int CompareTo(Crate crate)
        {
            int result = -1;
            if(crate.IdNumber == IdNumber && crate.Price == Price && crate.TimeWhenUnloaded == TimeWhenUnloaded)
            {
                result = 0;
            }
            return result;
        }
    }
}
