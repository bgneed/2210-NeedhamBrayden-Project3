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
            //This is where the time increments should actually be added. Over the course of one time increment things will happen in
            //different classes. For example, the warehouse class will transfer one truck to the next available dock if possible. If not
            //the truck will stay in the entrance wait line. At each dock one crate can be unloaded, and a truck can leave in one 
            //increment
            //Warehouse warehouse = new Warehouse();
            //warehouse.Run();

            StreamWriter csvOut = new StreamWriter(@"..\..\..\..\SimulationResults.csv");

            //What I would recommend doing is having a loop that goes through each dock and updates it and then writes to the file
            //for each dock as they are updated.
            Warehouse warehouse = new Warehouse();
            Road entranceRoad = new Road(warehouse);
            foreach(Dock dock in entranceRoad.Warehouse.Docks)
            {

            }
        }
        /// <summary>
        /// This method will write to the CSV file what 
        /// </summary>
        /// <param name="eventOcurred"></param>
        public void WriteToFile(Truck truck, Crate crate, int eventOcurred, StreamWriter stream)
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
            stream.WriteLine($"Unload Time: {crate.TimeWhenUnloaded}, Trucker: {crate.DriversName}, Company: {crate.CompanyName}" +
                $", ID Num: {crate.IdNumber}, Price of Crate: {crate.Price}, Scenario: {scenario}");
        }
    }
}