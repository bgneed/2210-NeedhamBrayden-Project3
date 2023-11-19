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
* Author’s names: Brayden Needham, Jacob Sullins, and Terry McCulley *
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
        public uint TimeWhenUnloaded;
        public string DriversName { get; set; }
        public string CompanyName { get; set; }

        public Crate() 
        {
            IdNumber = "0";
            Price = 0;
        }
        public Crate(string idNumber, Truck truck)
        {
            IdNumber = idNumber;
            DriversName = truck.Driver;
            CompanyName = truck.DeliveryCompany;
            Random random = new Random();
            double price = random.Next(50, 501);
            Price = price;
        }
        public Crate(Crate copyCrate)
        {
            IdNumber = copyCrate.IdNumber;
            Price = copyCrate.Price;
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

        public void SetTime(uint time)
        {
            TimeWhenUnloaded = time;
        }

        public uint GetTime()
        {
            return TimeWhenUnloaded;
        }
    }
}
