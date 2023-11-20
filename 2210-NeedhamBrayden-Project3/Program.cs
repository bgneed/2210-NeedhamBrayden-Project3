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
            for (int i = 0; i < 3; i++)
            {
                Warehouse warehouse = new Warehouse(i);
                warehouse.Run();
            }
        }
        ///// <summary>
        ///// This method will write to the CSV file what 
        ///// </summary>
        ///// <param name="eventOcurred"></param>
        //public static void WriteToFile(Crate crate, int eventOcurred, StreamWriter stream)
        //{
        //    string scenario = "";
        //    switch (eventOcurred)
        //    {
        //        case 1:
        //        scenario = "A crate was unloaded, but the truck still has more crates to unload.";
        //        break;
        //        case 2:
        //        scenario = "A crate was unloaded, and the truck was sent off.";
        //        break;
        //        case 3:
        //        scenario = "A new truck entered the dock, and a crate was unloaded.";
        //        break;
        //    }

        //    if (crate == null)
        //    {
        //        return;
        //    }
        //    stream.WriteLine($"Unload Time: {crate.TimeWhenUnloaded}, Trucker: {crate.DriversName}, Company: {crate.CompanyName}" +
        //        $", ID Num: {crate.IdNumber}, Price of Crate: {crate.Price}, Scenario: {scenario}");
        //}

        //public void SumOfSimulation()
        //{

        //}
    }
}