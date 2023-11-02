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
* Author’s name and email: Brayden Needham | needhambg@etsu.edu      *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public class Crate
    {
        public string IdNumber {  get; set; }
        public double Price { get; set; }  

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
            double price = random.Next(50,501);
            Price = price;
        }
    }
}
