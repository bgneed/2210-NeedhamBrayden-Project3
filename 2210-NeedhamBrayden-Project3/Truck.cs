﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Truck.cs                                                *   
*--------------------------------------------------------------------*
* Author’s names: Brayden Needham, Jacob Sullins, and Terry McCulley *
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

        public uint ArrivalTime;

        public Stack<Crate> Trailer { get; set; }

        public Truck(uint arrivalTime)
        {
            Driver = AssignDriver(); 
            DeliveryCompany = AssignCompany();
            ArrivalTime = arrivalTime;
            Trailer = new();
            Load(GenerateCrates());
        }

        public Truck()
        {
            Driver = AssignDriver();
            DeliveryCompany = AssignCompany();
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
        /// A method used to Push new crates into the stack named Trailer
        /// </summary>
        /// <param name="crates">The list of crates to push</param>
        public void Load(List<Crate> crates)
        {
            foreach (Crate crate in crates)
            {
                Load(crate);
            }
        }

        /// <summary>
        /// Generates a collection of random sized to be loaded into the trailer
        /// </summary>
        /// <returns></returns>
        public List<Crate> GenerateCrates()
        {
            Random r = new Random();
            int numOfCrates = r.Next(0, 6);

            List<Crate> listOfCrates = new List<Crate>();

            for (int i = 0; i <= numOfCrates; i++)
            {
                string crateID = "C" + $"{i}";
                Crate crate = new Crate(crateID, this);//Add time into here as well as pass in the truck object itself if possible
                listOfCrates.Add(crate);
            }

            return listOfCrates;
        }

        /// <summary>
        /// A method to remove the last crate that was added to the trucks trailer
        /// </summary>
        /// <returns>The unloaded crate and the time the crate was unloaded</returns>
        public Crate Unload(uint unloadTime) //Changed unload time from an out variable to an in variable
        {
            Crate crate = Trailer.Pop();
            crate.SetTime(unloadTime);
            return crate;
        }

        /// <summary>
        /// A method that will assign a random truck driver name to the truck.
        /// Pulls from an array of 100 driver names generated by ChatGPT. Uses the random class to generate a random index in the array
        /// </summary>
        /// <returns></returns>
        public string AssignDriver()
        {
            #region TruckerNames
            string[] truckDriverNames = new string[]
{
    "Mike 'Big Rig' Johnson",
    "Sarah 'Highway Queen' Rodriguez",
    "Jack 'Freightliner' Thompson",
    "Lisa 'Road Warrior' Parker",
    "Tony 'Diesel King' Smith",
    "Michelle 'Miles Away' Anderson",
    "Frank 'Trucker Tornado' Davis",
    "Rachel 'Steel Thunder' Mitchell",
    "Dave 'Cargo Cruiser' Williams",
    "Wendy 'High Beam' Turner",
    "Mark 'Gritty Gearshift' Wilson",
    "Jessica 'Hauling Hero' Clark",
    "Brad 'Long Hauler' Evans",
    "Angela 'Road Rebel' Adams",
    "Tom 'Rig Runner' Brown",
    "Linda 'Interstate Star' Moore",
    "Todd 'Truckin' Troubadour' Taylor",
    "Karen 'Lone Wolf' Carter",
    "Chris 'Thunderstruck' Martin",
    "Erin 'Diesel Duchess' Jackson",
    "Steve 'Mud Flap' Garcia",
    "Kelly 'Highway Hawk' Hernandez",
    "Gary 'Cargo Crusader' Lewis",
    "Amy 'Breeze Rider' Hill",
    "Scott 'Freeway Fury' Phillips",
    "Amanda 'Storm Chaser' White",
    "Jim 'Big Load' Foster",
    "Nicole 'Asphalt Angel' Green",
    "Brian 'Truckin' Titan' Morris",
    "Heather '18-Wheeler' Reed",
    "Ray 'Highway Hero' Cooper",
    "Lisa 'Gears Galore' Bailey",
    "Patrick 'Road Rambler' Stewart",
    "Olivia 'Speedy Delivery' Young",
    "Justin 'Freight Force' Robinson",
    "Emily 'Tanker Trailblazer' Hall",
    "Shane 'Rig Rider' Price",
    "Lauren 'Cargo Queen' Turner",
    "Robert 'Drivin' Dreamer' Perry",
    "Dana 'Mile Marker' Sanchez",
    "Alex 'High Gear' Butler",
    "Vanessa 'Rolling Thunder' Wright",
    "John 'Diesel Dynamo' Bennett",
    "Sarah 'Storm Surge' Gray",
    "Eric 'Trucker Trekker' Jenkins",
    "Karen 'Wheels of Fortune' Cox",
    "Michael 'Road Rescuer' Murphy",
    "Laura 'Highway Harmony' Collins",
    "Greg 'Gearshift Gladiator' Ross",
    "Lisa 'Freight Fiend' Foster",
    "Chris 'Haulin' Hope' Martinez",
    "Rachel 'Rapid Relay' Mitchell",
    "Paul 'Transport Titan' Turner",
    "Kim 'Midnight Marauder' Parker",
    "Todd 'Interstate Instigator' Baker",
    "Jessica 'The Truckin' Trooper' Lewis",
    "Brian 'Mile Marker Maverick' Fisher",
    "Tara 'Truckin' Trailblazer' Reed",
    "David 'Rolling Renegade' Jackson",
    "Holly 'Highway Healer' Peterson",
    "Ron 'Freeway Firebrand' Bennett",
    "Maria 'Cargo Crusader' Rodriguez",
    "Alan 'Highway Heroic' Wilson",
    "Angela 'Mud Flap Maven' Thomas",
    "Peter 'Trucker Trailmaster' Wright",
    "Sarah 'Highway Harmonizer' Turner",
    "Joe 'Cargo Commander' Martin",
    "Lisa 'Truckin' Tempest' Baker",
    "Mike 'Diesel Daredevil' Mitchell",
    "Jenny 'Road Racer' Adams",
    "Kevin 'Freight Force' Campbell",
    "Carla 'Hauling Heroine' Sanchez",
    "James 'Highway Hawk' Johnson",
    "Rachel 'Gearshift Gladiator' Davis",
    "Andy 'Truckin' Tornado' Stewart",
    "Stacy 'Lone Wolf' Evans",
    "Patrick 'High Beam' Carter",
    "Donna 'High Gear' Garcia",
    "Scott 'Miles Away' Hill",
    "Cindy 'Truckin' Troubadour' Reed",
    "Robert 'Cargo Crusader' Foster",
    "Lisa 'Road Rebel' Turner",
    "Mark 'Gritty Gearshift' Mitchell",
    "Amanda 'Steel Thunder' Robinson",
    "Brian 'Hauling Hope' Reed",
    "Jessica 'Breeze Rider' Martin",
    "David 'Trucker Trekker' Anderson",
    "Michelle 'Storm Chaser' Cooper",
    "John 'Truckin' Titan' Young",
    "Emily 'Rig Runner' Taylor",
    "Alex 'Cargo Cruiser' Clark",
    "Kim 'Highway Queen' Brown",
    "Frank 'Big Load' Williams",
    "Nicole 'Rig Rider' Smith",
    "Brad 'Highway Harmony' Lewis",
    "Erin 'Speedy Delivery' Thompson",
    "Jason 'Diesel Dynamo' Moore",
    "Laura 'Interstate Star' Bennett",
    "Carlos 'Cargo Commander' Foster",
    "Sandy 'Trucker Trailblazer' Price"
};//Retreived through ChatGPT
            #endregion
            Random random = new Random();
            int trucker = random.Next(0, 100);
            return truckDriverNames[trucker];
        }

        /// <summary>
        /// A method that will assign a random trucking company name to the truck.
        /// Pulls from an array of 25 random company names genersted through ChatGPT.
        /// Uses the random class to generate a random index in the array of company names. 
        /// </summary>
        /// <returns></returns>
        public string AssignCompany()
        {
            #region CompanyNames
            string[] truckingCompanyNames = new string[]
            {
                "Speedy Freight Express",
                "Interstate Logistics",
                "Cargo Masters Inc.",
                "Highway Haulers Co.",
                "Eagle Transport Services",
                "Swift Roadways Ltd.",
                "Golden Wheel Carriers",
                "Thunderstruck Transports",
                "Pioneer Trucking Solutions",
                "American Freightways",
                "Trucker's Choice Transport",
                "Green Line Express",
                "Redwood Trucking Group",
                "Silver Arrow Shipping",
                "Blue Horizon Transports",
                "Yellow Ribbon Logistics",
                "Rocky Mountain Carriers",
                "Starlight Freight Services",
                "Patriot Road Warriors",
                "High Gear Transport",
                "Big Sky Express",
                "Freedom Truck Lines",
                "Sunrise Hauling Co.",
                "Windy City Carriers",
                "Sunset Transport Systems"
            };//Retrieved through ChatGPT

            #endregion
            Random random = new Random();
            int trucker = random.Next(0, 25);
            return truckingCompanyNames[trucker];
        }
    }
}
