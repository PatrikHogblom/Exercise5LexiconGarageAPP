using Exercise5LexiconGarage.Vehicles;
using System.Reflection;
using System.Linq;
using Exercise5LexiconGarage.Helpers;
using System.Security.Cryptography;

namespace Exercise5LexiconGarage.Garages
{
    public class GarageHandler : IGarageHandler
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

        public bool garageListIsNotNull()
        {
            if(garageList.Count != 0) 
            { 
                return true;
            }
            return false;
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
                if (garageList[i].GarageName.Trim().ToLower() == name.ToLower().Trim())
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


                string input = InputHandler.GetStringInput("Choose which type of Vehcile you want to park in the garage. ");
                switch (input.Trim())
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

            int totEngnies = InputHandler.GetIntegerInput("Insert Number of enginges: ");
            AirPlane airPlane = new AirPlane(regNumber, color, totWheels, model, year, totEngnies);

            return airPlane;
        }

        private Boat CreateBoatObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            double boatLength = InputHandler.GetDoubleInput("Insert Length of boat in m: ");
            Boat boat = new Boat(regNumber, color, totWheels, model, year, boatLength);

            return boat;
        }

        private Bus CreateBusObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            int numberofSeats = InputHandler.GetIntegerInput("Insert number of seats the bus have: ");

            Bus bus = new Bus(regNumber, color, totWheels, model, year, numberofSeats);

            return bus;
        }

        private Car CreateCarObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            string fuelType = InputHandler.GetStringInput("Insert fueltype: ");

            Car car = new Car(regNumber, color, totWheels, model, year, fuelType);

            return car;
        }

        private Motorcycle CreateMotorCycleObject()
        {
            string regNumber, color, model, year;
            int totWheels;
            InputVehicleVariables(out regNumber, out color, out totWheels, out model, out year);

            double cylinderVolume = InputHandler.GetDoubleInput("Insert the Volume of the cylinder in");
            Motorcycle motorcycle = new Motorcycle(regNumber, color, totWheels, model, year, cylinderVolume);

            return motorcycle;
        }

        private static void InputVehicleVariables(out string regNumber, out string color, out int totWheels, out string model, out string year)
        {
            
            regNumber = InputHandler.GetStringInput("Input your register of the vehicle, for example abc123/ABC123");
            //check so that the regNumber doesn't exist in the garage before we add in
            color = InputHandler.GetStringInput("Input your color of the Vehcile: ");
            totWheels = InputHandler.GetIntegerInput("Insert the number of wheels your vehicle have: ");
            model = InputHandler.GetStringInput("Input the model of the vehcile: ");
            year = InputHandler.GetIntegerInput("Input the the year your vehicle were made, for example 2010, 2022, 1999: ").ToString();
        }

        //get specific garage
        public Garage<Vehicle> GetGarageByIndex(int index)
        {
            return garageList[index];
        }

        public void RemoveVehicle(Garage<Vehicle> currentGarage)
        {
            //1. print the existing vehicles
            //currentGarage.printVehicles();
            //2. choose the registernumber you want to remove
            string regNum = InputHandler.GetStringInput("Enter the registernumber you want to remove: ");
            currentGarage.RemoveVehicleByRegisterNumber(regNum);

            //currentGarage.printVehicles();
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
            int selectedIndex = InputHandler.GetIntegerInput("Enter the index of the type to choose from (0, 1, 2, ...):");
            
            if (subclassMap.ContainsKey(selectedIndex))
            {
                string selectedSubclass = subclassMap[selectedIndex].Name.ToString();
                Console.WriteLine($"You selected: {selectedSubclass}");
                currentGarage.searchVehiclesForAType(selectedSubclass);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again next time and enter a valid index.");
            }
            

        }

        public void searchVehicleByRegisterNumber(Garage<Vehicle> currentGarage)
        {
            string regNumber = InputHandler.GetStringInput("Insert the register number of the vehicle you are searching for: ");
            bool regNumExist = currentGarage.searchVehicleByRegisterNumber(regNumber);
            if (regNumExist)
            {
                Console.WriteLine("The searched vehicle does exists in this garage");
            }
            else
            {
                Console.WriteLine("The searched Vehicle doesn't exist in this garage");
            }

        }

        public bool checkIfFilterIsEmpty(Vehicle[] resultFilter)
        {
            if(resultFilter.Length == 0)
            {
                Console.WriteLine("Filter have no match");
                return false;
            }
            return true;
        }

        public void searchByVehicleProperty(Garage<Vehicle> currentGarage)
        {
            Vehicle[] resultFilter = currentGarage.GetVehicles;
            
            string inputSelectedType = InputHandler.GetStringInput("Input Vehicle Type(or skip by writing 'skip')").ToLower().Trim();

            if (inputSelectedType != "skip" && !string.IsNullOrWhiteSpace(inputSelectedType))
            {
                resultFilter = currentGarage.FilterByVehicleType(inputSelectedType, resultFilter);
               
                if (resultFilter.Length == 0)
                {
                    Console.WriteLine("No vehicles match the specified Type. Exiting search.");
                    return; // Exit the method
                }
            }

            string inputRegNum = InputHandler.GetStringInput("Input Vehicle Registernumber(or skip by writing 'skip')").ToLower().Trim();
            if (inputRegNum != "skip" && !string.IsNullOrWhiteSpace(inputRegNum))
            {
                resultFilter = currentGarage.FilterByVehicleRegNum(inputRegNum, resultFilter);
                if (resultFilter.Length == 0)
                {
                    Console.WriteLine("No vehicles match the specified register number. Exiting search.");
                    return; // Exit the method
                }
            }

            string inputColor = InputHandler.GetStringInput("Input Vehicle Color(or skip by writing 'skip')").ToLower().Trim();
            if (inputColor != "skip" && !string.IsNullOrWhiteSpace(inputColor))
            {
                resultFilter  = currentGarage.FilterByVehicleColor(inputColor, resultFilter);
                if (resultFilter.Length == 0)
                {
                    Console.WriteLine("No vehicles match the specified color. Exiting search.");
                    return; // Exit the method
                }
            }

            //todo: if time permites, remake this code
            string inputWheels = InputHandler.GetStringInput("Input Vehicle number of wheels(or skip by writing 'skip')").ToLower().Trim();
            int.TryParse(inputWheels, out int numWheels);
            if (inputWheels != "skip" && !int.IsNegative(numWheels))
            {
                resultFilter = currentGarage.FilterByNumWheels(numWheels, resultFilter);
                if (resultFilter.Length == 0)
                {
                    Console.WriteLine("No vehicles match the specified number of wheels. Exiting search.");
                    return; // Exit the method
                }
            }

            string inputModel = InputHandler.GetStringInput("Input Vehicle Model(or skip by writing 'skip')").ToLower().Trim();
            if (inputModel != "skip" && !string.IsNullOrWhiteSpace(inputModel))
            {
                resultFilter = currentGarage.FilterByVehicleModel(inputModel, resultFilter);
                if (resultFilter.Length == 0)
                {
                    Console.WriteLine("No vehicles match the specified model. Exiting search.");
                    return; // Exit the method
                }
            }

            string inputYear = InputHandler.GetStringInput("Input Vehicle Year(or skip by writing 'skip')").ToLower().Trim();
            if (inputYear != "skip" && !string.IsNullOrWhiteSpace(inputYear))
            {
                resultFilter = currentGarage.FilterByVehicleYear(inputYear, resultFilter);
                if (resultFilter.Length == 0)
                {
                    Console.WriteLine("No vehicles match the specified year. Exiting search.");
                    return; // Exit the method
                }
            }

            foreach (var item in resultFilter)
            {
                Console.WriteLine(item.Stats());
            }
        }

    }
}