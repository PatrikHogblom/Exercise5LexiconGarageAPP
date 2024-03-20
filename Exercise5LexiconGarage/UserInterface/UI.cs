using Exercise5LexiconGarage.Garages;

namespace Exercise5LexiconGarage
{
    public class UI
    {
        private static GarageHandler garagehandler = new GarageHandler();
        public static void MainMenu()
        {
            bool programRun = true;
            do
            {
                Console.WriteLine("1. Create garage and its capacity");
                Console.WriteLine("2. Choose garage to use and go to its submenu: ");
                Console.WriteLine("3. Exit the program");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateGarageObject();
                        garagehandler.PrintGaragesStored();
                        break;
                    case "2":
                        //1.choose which garage you want to use
                        garagehandler.PrintGaragesStored();

                        Console.WriteLine("Enter the name of garage you want to use: ");
                        string inputGarageName = Console.ReadLine();

                        //get the index of position of tha garage name
                        int garageIndex = garagehandler.GetGarageIndexByName(inputGarageName);

                        //2. create a submeny wheras we add vehicles to the garage
                        SubMenu(garageIndex);
                        break;
                    case "3":
                        programRun = false;
                        break;
                }
            }while (programRun);
        }

        private static void SubMenu(int indexGarage)
        {
            bool programRun = true;
            do
            {
                Console.WriteLine("1. Park vehicle: ");
                Console.WriteLine("2. Remove vehicle: ");
                Console.WriteLine("3. print all parked vehicles in the garage: ");
                Console.WriteLine("4. print all parked vehicles according a type in the garage: ");
                Console.WriteLine("5. Search after a vehicle in the garage according to registernumber: ");
                Console.WriteLine("6. Search after vehicles using a text");
                Console.WriteLine("7. Go back to main menu");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        throw new NotImplementedException();
                        break;
                    case "2":
                        throw new NotImplementedException();
                        break;
                    case "3":
                        throw new NotImplementedException();
                        break;
                    case "4":
                        throw new NotImplementedException();
                        break;
                    case "5":
                        throw new NotImplementedException();
                        break;
                    case "6":
                        throw new NotImplementedException();
                        break;
                    case "7":
                        programRun = false;
                        break;
                }
            } while (programRun);
        }

        private static void ParkVehicleInGarage(Garage garage)
        {
            //create a garagehandler, here we add the vehicle to a vehilce class 

            throw new NotImplementedException();
        }

        //gör detta i garagehandler istället?
        public static void CreateGarageObject()
        {
            //todo: asks the user to input capacity, name, adress, city of the garage
            //before you create the object
            //have a try catch here here in case
            try 
            {
                Console.WriteLine("Enter capacity of parking lots in the garage: ");
                int capacity;
                int.TryParse(Console.ReadLine(), out capacity);

                Console.WriteLine("Enter the name of the garage:");
                string garageName = Console.ReadLine();

                Console.WriteLine("Enter the address of the garage:");
                string address = Console.ReadLine();

                Console.WriteLine("Enter the city of the garage: ");
                string city = Console.ReadLine();

                //add the garage to the garageList in garageHandler 
                garagehandler.addGarageToList(capacity, garageName, address, city);
                
                Console.WriteLine("Garage created sucessfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong when creating garage object: " + ex.Message);
            }
        }
    }
}