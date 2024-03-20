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

        //Update garage 

        //Enter capacity


        //enter name

        //enter city 

        //add garage to a list of garages





    }
}