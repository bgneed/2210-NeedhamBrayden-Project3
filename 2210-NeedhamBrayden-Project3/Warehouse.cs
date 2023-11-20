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
* Author’s names: Brayden Needham, Jacob Sullins, and Terry McCulley *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    public class Warehouse
    {
        public List<Dock> Docks { get; set; }
        public Queue<Truck> Entrance { get; set; }
        public Road Road { get; set; }
        public StreamWriter csvOut;


        public Warehouse() 
        {
            Docks = new List<Dock>();
            Entrance = new Queue<Truck>();
            Road = new(this);
            csvOut = new StreamWriter(@"..\..\..\..\SimulationResults.csv");
        }
        
        //In here we need to Assign Trucks in the entrance to each dock as they become available
        public void AssignTruckToDock(uint time)
        {
            bool emptyDockFound = false;
            
            for(int currentDock = 0; currentDock < Docks.Count; currentDock++)
            {
                if (Docks[currentDock].CurrentTruck == null)
                {
                    emptyDockFound = true;

                    if (Entrance.Count == 0)
                    {
                        Road.AddToWaitLine();
                        AddToEntrance(Road.WaitLine);
                    }

                    Docks[currentDock].NewTruckIn(Entrance.Dequeue(), time);
                }
            }
        }
        /// <summary>
        /// This method brings trucks that are on the road and brings them to the entrance of the warehouse so that they may
        /// be sorted to each dock
        /// </summary>
        /// <param name="trucksFromRoad"></param>
        public void AddToEntrance(Queue<Truck> trucksFromRoad)
        {
            for(int i = 0; i < trucksFromRoad.Count;i++)
            {
                Entrance.Enqueue(trucksFromRoad.Dequeue());
            }
        }

        //This is where the time increments should actually be added. Over the course of one time increment things will happen in
        //different classes. For example, the warehouse class will transfer one truck to the next available dock if possible. If not
        //the truck will stay in the entrance wait line. At each dock one crate can be unloaded, and a truck can leave in one 
        //increment
        public void Run()
        {
            int numOfDocks = 5; //We can update this as needed
            Road.Initialize(numOfDocks);
            int totalNumOfTrucks = numOfDocks;
            int cratesUnloaded = 0;
            double totalRevenue = 0;

            using (csvOut)
            {
                while (Road.GetTimeFrame() != "End of Day")
                {
                    foreach (Dock dock in Docks)
                    {

                        int eventOcurred = 0;
                        if (Entrance.Count == 0)
                        {
                            Road.AddToWaitLine();
                            AddToEntrance(Road.WaitLine);
                        }

                        dock.UpdateDock(Entrance, Road.Time, out eventOcurred);

                        if (eventOcurred == 3)
                        {
                            totalNumOfTrucks++;
                        }

                        totalRevenue += dock.CurrentCrate.Price;
                        dock.OperatingCost += 100;
                        cratesUnloaded++;
                        WriteToFile(dock.CurrentCrate, eventOcurred, csvOut);
                    }
                    Road.IncrementTime();
                }

                SumOfSimulation(csvOut, totalNumOfTrucks, Docks, cratesUnloaded, totalRevenue);
            }
        }

        /// <summary>
        /// This method will write to the CSV file what 
        /// </summary>
        /// <param name="eventOcurred"></param>
        public static void WriteToFile(Crate crate, int eventOcurred, StreamWriter stream)
        {
            string scenario = "";
            switch (eventOcurred)
            {
                case 1:
                    scenario = "A crate was unloaded, but the truck still has more crates to unload.";
                    break;
                case 2:
                    scenario = "A crate was unloaded, and the truck was sent off.";
                    break;
                case 3:
                    scenario = "A new truck entered the dock, and a crate was unloaded.";
                    break;
            }

            if (crate == null)
            {
                return;
            }
            stream.WriteLine($"Unload Time: {crate.TimeWhenUnloaded}, Trucker: {crate.DriversName}, Company: {crate.CompanyName}" +
                $", ID Num: {crate.IdNumber}, Price of Crate: {crate.Price}, Scenario: {scenario}");
        }

        public void SumOfSimulation(StreamWriter stream, int totalNumOfTrucks, List<Dock> docks, int cratesUnloaded, double revenue)
        {
            stream.WriteLine();
            stream.WriteLine($"Total number of trucks: {totalNumOfTrucks}");

            string remainingTrucks = "\nTrucks that were not unloaded before closing:";
            foreach (Dock dock in docks)
            {
                if (dock.CurrentTruck != null)
                {
                    remainingTrucks += $"\n{dock.CurrentTruck.Driver}'s truck.";
                }
            }
            stream.WriteLine(remainingTrucks);

            string costPerDock = "\nCost for operating each dock: ";
            for (int i = 0; i < docks.Count; i++)
            {
                costPerDock += $"\nDock {i + 1}: ${docks[i].OperatingCost}";
            }
            stream.WriteLine(costPerDock);

            string dockRevenue = "\nRevenue for each dock: ";
            for (int i = 0; i < docks.Count; i++)
            {
                double profit = Math.Round(docks[i].TotalSales / docks[i].OperatingCost, 2);
                dockRevenue += $"\nDock {i + 1}: ${profit}";
            }
            stream.WriteLine(dockRevenue);

            stream.WriteLine($"\nNumber of crates unloaded: {cratesUnloaded}");

            stream.WriteLine($"\nTotal value of crates unloaded: ${revenue}");

            stream.WriteLine($"\nAverage value of the crates: ${Math.Round(revenue / cratesUnloaded), 2}");
        }
    }

    
}
