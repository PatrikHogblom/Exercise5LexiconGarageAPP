using Exercise5LexiconGarage.Vehicles;
using System.Reflection;
using System.Transactions;

namespace Exercise5LexiconGarage.Garages
{
    public class GarageHandler
    {
        private List<Garage<Vehicle>> garageList;

        //mainmenu methods:
        public GarageHandler()
        {
            // Initialize garageList in the constructor
            garageList = new List<Garage<Vehicle>>();
        }

        //add garage to a list of garages
        public void addGarageToList(int capacity, string name, string address, string city)
        {
            garageList.Add(new Garage<Vehicle>(capacity, name, address, city));
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

        public void AddVehicle(Garage<Vehicle> garage)
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
                Console.WriteLine("6. Go back to submenu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        garage.addVehicle(CreateAirplaneObject());
                        break;
                    case "2":
                        garage.addVehicle(CreateBoatObject());
                        break;
                    case "3":
                        garage.addVehicle(CreateBusObject());
                        break;
                    case "4":
                        garage.addVehicle(CreateCarObject());
                        break;
                    case "5":
                        garage.addVehicle(CreateMotorCycleObject());
                        break;
                    case "6":
                        ProgramRun = false;
                        break;
                }

            } while (ProgramRun);



            //2.add the vehicle to the Vehicle array in Garage Class 
        }

        private AirPlane CreateAirplaneObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            Console.WriteLine("Insert Number of enginges: ");
            int totEngnies;
            int.TryParse(Console.ReadLine(), out totEngnies);

            AirPlane airPlane = new AirPlane(regNumber, color, totWheels, model, year, totEngnies);

            return airPlane;
        }

        private Boat CreateBoatObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            Console.WriteLine("Insert Length of boat: ");
            double boatLength;
            double.TryParse(Console.ReadLine(), out boatLength);

            Boat boat = new Boat(regNumber, color, totWheels, model, year, boatLength);

            return boat;
        }

        private Bus CreateBusObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            Console.WriteLine("Insert number of seats: ");
            int numberofSeats;
            int.TryParse(Console.ReadLine(), out numberofSeats);

            Bus bus = new Bus(regNumber, color, totWheels, model, year, numberofSeats);

            return bus;
        }

        private Car CreateCarObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            Console.WriteLine("Insert fueltype: ");
            string fuelType = Console.ReadLine();

            Car car = new Car(regNumber, color, totWheels, model, year, fuelType);

            return car;
        }

        private Motorcycle CreateMotorCycleObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            Console.WriteLine("Insert CylinderVoulme: ");
            double cylinderVolume;
            double.TryParse(Console.ReadLine(), out cylinderVolume);


            Motorcycle motorcycle = new Motorcycle(regNumber, color, totWheels, model, year, cylinderVolume);

            return motorcycle;
        }

        private static void InputVehicleVariables(out string regNumber, out string color, out int totWheels, out string model, out string year)
        {
            //todo: if able then create a for statement to input all values of each subclass?
            Console.WriteLine("Insert RegisterNumber: ");
            regNumber = Console.ReadLine();
            Console.WriteLine("Insert Color: ");
            color = Console.ReadLine();
            Console.WriteLine("Insert total Wheels: ");
            int.TryParse(Console.ReadLine(), out totWheels);

            Console.WriteLine("Insert model: ");
            model = Console.ReadLine();
            Console.WriteLine("Insert year: ");
            year = Console.ReadLine();
        }

        //get specific garage
        public Garage<Vehicle> GetGarageByIndex(int index)
        {
            return garageList[index];
        }

        public void RemoveVehicle(Garage<Vehicle> currentGarage)
        {
            //what to do here 
            //1. print the existing vehicles
            currentGarage.printVehicles();
            //2. choose the registernumber you want to remove
            Console.WriteLine("Enter the registernumber you want to remove: ");
            string regNum = Console.ReadLine();//todo cvheck if the registerrnumber exists or not later

            currentGarage.RemoveVehicleByRegisterNumber(regNum);

            currentGarage.printVehicles();
        }

        public void printVehiclesByType(Garage<Vehicle> currentGarage)
        {
            //get all types 
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            Console.WriteLine("Types of a vehicle that you can search for: ");

            //Directory to store index-subclass mappings
            Dictionary<int, Type> subclassMap = new Dictionary<int, Type>();

            int index = 0;
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(Vehicle)))
                {
                    Console.WriteLine($"{index}: {type.Name}");
                    subclassMap[index++] = type;
                }
            }

            //promt the user to choose a index
            Console.WriteLine("Enter the index of the type to choose from (0, 1, 2, ...):");
            if(int.TryParse(Console.ReadLine(), out int selectedIndex))
            {
                if (subclassMap.ContainsKey(selectedIndex))
                {
                    string selectedSubclass = subclassMap[selectedIndex].Name.ToString();
                    Console.WriteLine($"You selected: {selectedSubclass}");
                    currentGarage.searchVehiclesForAType(selectedSubclass);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid index.");
                }
            }
            
        }

        public void searchVehicleByRegisterNumber(Garage<Vehicle> currentGarage)
        {
            Console.WriteLine("Insert the register number of the vehicle you are searching for: ");
            string regNumber = Console.ReadLine();

            bool regNumExits  = currentGarage.searchVehicleByRegisterNumber(regNumber);

            if(regNumExits)
            {
                Console.WriteLine("The searched vehicle does exists in this garage");
            }
            else
            {
                Console.WriteLine("The searched Vehicle doesn't exist in this garage");
            }

        }
    }
}