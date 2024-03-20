using System.Runtime.InteropServices;

namespace Exercise5LexiconGarage.Garages
{
    internal class GarageHandler
    {
        private List<Garage> garageList;

        //mainmenu methods:
        public GarageHandler()
        {
            // Initialize garageList in the constructor
            garageList = new List<Garage>();
        }

        //add garage to a list of garages
        public void addGarageToList(int capacity, string name, string address, string city)
        {
            garageList.Add(new Garage(capacity, name, address, city));
        }

        //print the garages
        public void PrintGaragesStored()
        {
            Console.WriteLine("---------------Garages----------------");
            foreach (var item in garageList)
            {
                Console.WriteLine($"Name: {item.GarageName} Capacity: {item.GarageCapacity} Adress: {item.GarageAddress} City: {item.GarageCity} ");
            }
            Console.WriteLine("--------------------------------------");
        }

        //method to get the index of a garage based on its name
        public int GetGarageIndexByName(string name)
        {
            for (int i = 0; i < garageList.Count; i++)
            {
                if (garageList[i].GarageName == name)
                {
                    return i;
                }
            }
            return -1;
        }

        //Update garage? 
        //Enter capacity?
        //enter name?
        //enter city?

        //submenu 
        //add vechiles to vehiles[] to specific garage
        //remove vehicles


    }
}