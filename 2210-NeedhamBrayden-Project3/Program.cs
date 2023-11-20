/*********************************************************************
*--------------------------------------------------------------------*
* Project name: 2210-NeedhamBrayden-Project3                         *
* File name: Program.cs                                              *   
*--------------------------------------------------------------------*
* Author’s names: Brayden Needham, Jacob Sullins, and Terry McCulley *
* Course-Section: 2210-001                                           *   
* Creation Date:11/2/2023                                            *   
* -------------------------------------------------------------------*
**********************************************************************/
namespace _2210_NeedhamBrayden_Project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Warehouse warehouse = new Warehouse();/*
            Road r = new(warehouse);
            r.Time = 300;
            r.Initialize(5);
            int w = 1;
            Console.WriteLine(r.GetTimeFrame());
            Console.WriteLine(r.WaitLine.Count);

            foreach (Dock d in warehouse.Docks)
            {
                Console.WriteLine($"dock {w}");
                if (d.CurrentTruck != null)
                {
                    Console.WriteLine(d.CurrentTruck.Driver);
                    int count = d.CurrentTruck.Trailer.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Crate c = d.CurrentCrate;
                        d.RemoveCrate(r.Time);
                        Console.WriteLine(c.IdNumber);
                    }
                }

                w++;

            }

            Console.ReadLine();*/
            warehouse.Run();

            /*
            StreamWriter csvOut = new StreamWriter(@"..\..\..\..\SimulationResults.csv");

            //What I would recommend doing is having a loop that goes through each dock and updates it and then writes to the file
            //for each dock as they are updated.
            Warehouse Warehouse = new Warehouse();
            Road entranceRoad = new Road(warehouse);
            int numOfDocks = 5; //We can update this as needed
            entranceRoad.Initialize(numOfDocks);
            
            using (csvOut)
            {
                while (entranceRoad.GetTimeFrame() != "End of Day")
                {
                    foreach (Dock dock in warehouse.Docks)
                    {
                        int eventOcurred = 0;
                        dock.UpdateDock(warehouse.Entrance, entranceRoad.Time, out eventOcurred);
                        WriteToFile(dock.CurrentCrate, eventOcurred, csvOut);
                    }
                    entranceRoad.UpdateTimeViaDock();
                }
            }*/
                
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

        public void SumOfSimulation()
        {

        }
    }
}