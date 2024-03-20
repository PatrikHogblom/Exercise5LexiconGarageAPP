using Exercise5LexiconGarage.Garages;

namespace Exercise5LexiconGarage
{
    public class UI
    {
        private static List<Garage> garageList = new List<Garage>();//store the created garage objects  
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
                        PrintGaragesStored();
                        break;
                    case "2":
                        throw new NotImplementedException();
                        break;
                    case "3":
                        programRun = false;
                        break;
                }
            }while (programRun);
        }

        public static void PrintGaragesStored()
        {
            Console.WriteLine("---------------Garages----------------");
            foreach (var item in garageList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("--------------------------------------");
        }

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

                //Create the object of the garage 
                Garage garage = new Garage(capacity, garageName, address, city);
                garageList.Add(garage);

                Console.WriteLine("Garage created sucessfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}