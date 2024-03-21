using Exercise5LexiconGarage.Vehicles;
using System.Runtime.InteropServices;

namespace Exercise5LexiconGarage.Garages
{
    public class GarageHandler
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

        public void AddVehicle(Garage garage)
        {
            //what to do here? 
            //1.create the Vehicle object
            //2.create a switch statement of which type of vehicle object you want to add?
            bool ProgramRun = true;
            do
            {
                Console.WriteLine("1. Add a Airplane");
                Console.WriteLine("2. Add a Boat");
                Console.WriteLine("3. Add a Bus");
                Console.WriteLine("4. Add a Car");
                Console.WriteLine("5. Add a Motorcycle");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AirPlane airPlane = new AirPlane("123","RED", "6", "airtoo", "1996", 3 );
                        garage.addVehicle(airPlane);
                        ProgramRun = false;
                        break;
                    case "2":
                        throw new NotImplementedException();
                        break ;
                    case "3":
                        throw new NotImplementedException();
                        break;
                    case "4":
                        throw new NotImplementedException();
                        break;
                    case "5":
                        throw new NotImplementedException();
                        break;
                }
                
            }while (ProgramRun);



            //2.add the vehicle to the Vehicle array in Garage Class 
        }

        //get specific garage
        public Garage GetGarageByIndex(int index)
        {
            return garageList[index];
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