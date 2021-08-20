using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JSON
{
    class InventoryData
    {
        public InventoryData()
        {
            int customerOption;
            Console.WriteLine("Choose one Option to Perform Action :");
            Console.WriteLine("choose 1 to Add Details ");
            Console.WriteLine("Choose 2 to Display Details ");
            customerOption = int.Parse(Console.ReadLine());

            switch (customerOption)
            {
                case 1:
                    List<Library> inventoryList = new List<Library>();

                    Library inventory = new Library("Rice", 350, 80);
                    Library inventory1 = new Library("Pulses", 550, 90);
                    Library inventory2 = new Library("Wheats", 800, 110);

                    inventoryList.Add(inventory);
                    inventoryList.Add(inventory1);
                    inventoryList.Add(inventory2);
 
                    string json = JsonConvert.SerializeObject(inventoryList);
                    File.WriteAllText(@"DataInventary1.json", json);
                    Console.WriteLine("Data Stored");
                    break;

                case 2:

                    Console.WriteLine("Dispaly Inventory Items");
                    Console.WriteLine("-----------------------");

                    
                    string datafile = File.ReadAllText(@"DataInventary1.json");
                    List<Library> returnDataObj = JsonConvert.DeserializeObject<List<Library>>(datafile);

                    foreach (var form in returnDataObj)
                    {

                        Console.WriteLine("Name : " + form.Name);
                        Console.WriteLine("Weight : " + form.Weight);
                        Console.WriteLine("Price : " + form.Price);

                        Console.WriteLine("Total Value of {0} =  {1}: ", form.Name, (form.Weight * form.Price));
                        Console.WriteLine("---------------------------------");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Input !");
                    break;
            }
        }
    }
}