using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Truck.cs                                                *   
*--------------------------------------------------------------------*
* Author’s name and email: Brayden Needham | needhambg@etsu.edu      *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public class Truck
    {
        public string Driver {  get; set; }

        public string DeliveryCompany { get; set; }

        public Stack<Crate> Trailer { get; set; }

        public Truck()
        {
            Driver = "Bob";
            DeliveryCompany = "Bob Incorporated";
            Trailer = new Stack<Crate>();
        }

        /// <summary>
        /// A method used to Push a new crate into the stack named Trailer
        /// </summary>
        /// <param name="crate"></param>
        public void Load(Crate crate)
        {
            Trailer.Push(crate);
        }
        /// <summary>
        /// A method to remove the last crate that was added to the trucks trailer
        /// </summary>
        /// <returns></returns>
        public Crate Unload()
        {
            return Trailer.Pop();
        }
    }
}
