﻿using Exercise5LexiconGarage.Garages;
using Exercise5LexiconGarage.Helpers;
using Exercise5LexiconGarage.UserInterface;
using Exercise5LexiconGarage.Vehicles;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;

namespace Exercise5LexiconGarage
{

    public class UI : IUI
    {
        private static GarageHandler garagehandler = new GarageHandler();

        // displays the main menu, have three options: 
        // 1. create a garage by adding the capacity, name, address and city.
        // 2. choose a garage, checks if garages exists or it go back to main menu and tells user to create a garage first
        //    if garges exists, then go to the submenu of garage wheras we can park, unpark, see listed vehciles and more
        //3. exit the grogram

        public void DisplayMainMenu()
        {
               //to hard code to load a garage and its vehciles when starting application to test functions, can be a pain to add everything every time you run console
                /*garagehandler.addGarageToList(16, "test", "test 11", "Stockholm");
                Garage<Vehicle> currentGarage = garagehandler.GetGarageByIndex(garagehandler.GetGarageIndexByName("test"));
                currentGarage.addVehicle(new Car("qwe123", "röd", 4, "BMW", "2020", "gas"));
                currentGarage.addVehicle(new Car("asd123", "blå", 4, "volvo", "2010", "gas"));
                currentGarage.addVehicle(new Car("zxc123", "grå", 4, "subaru", "2010", "gas"));
                currentGarage.addVehicle(new Car("abc123", "röd", 4, "volvo", "2024", "gas"));
                currentGarage.addVehicle(new Car("fgh123", "rosa", 4, "BMW", "2020", "gas"));
                currentGarage.addVehicle(new Car("iop123", "black", 4, "volvo", "2010", "gas"));

                currentGarage.addVehicle(new AirPlane("air123", "röd", 6, "boeing", "2021", 4));
                currentGarage.addVehicle(new Bus("bus123", "röd", 8, "volvo", "1999", 24));
                currentGarage.addVehicle(new Motorcycle("mot123", "svart", 4, "honda", "2011", 24.4));
                currentGarage.addVehicle(new Boat("boa123", "röd", 4, "volvo", "2024", 15));
                currentGarage.addVehicle(new Bus("bus789", "blå", 8, "scania", "2020", 36));*/


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
                        if(garagehandler.garageListIsNotEmpty() == true)
                        {
                            garagehandler.PrintGaragesStored();
                            string inputGarageName = InputHandler.GetStringInput("Enter the name of garage you want to use: ");
                            //get the index of position of tha garage name
                            int garageIndex = garagehandler.GetGarageIndexByName(inputGarageName.Trim().ToLower());
                            //2. create a submeny wheras we add vehicles to the garage
                            if (garageIndex == -1)
                            {
                                Console.WriteLine("The garage you searched for don't exist");
                            }
                            else
                            {
                                DisplaySubMenu(garageIndex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please create a garage first!");
                        }
                        
                        break;
                    case "3":
                        programRun = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            } while (programRun);
        }

        // this submenu show a options to choose to do
        // 0. randomizes a vehcile to add to garage
        // 1. parks the vehcile by adding vehicles information
        // 2. unparks the vehciles by specifying the registernumber of vehcile
        // 3. prints all parked vehciles
        // 4.prints all parked vehciles by users option to choose which vehciles type to show on console 
        // 5.check if a vehcile exist in the garage by its registernumber
        // 6.filter out garage by Vehciles criteras, the program will ask you tol fill type, registernumber, 
        //   Color, model, number of wheels, year. The user can choose to write or skip the filtering 
        public void DisplaySubMenu(int indexGarage)
        {
            Garage<Vehicle> currentGarage = garagehandler.GetGarageByIndex(indexGarage);
            bool programRun = true;
            do
            {
                Console.WriteLine("0. Park Randomized Vehicle: ");
                Console.WriteLine("1. Park vehicle: ");
                Console.WriteLine("2. Unpark vehicle: ");
                Console.WriteLine("3. print all parked vehicles in the garage: ");
                Console.WriteLine("4. print all parked vehicles according a type in the garage: ");
                Console.WriteLine("5. Search after a vehicle in the garage according to registernumber: ");
                Console.WriteLine("6. Search after vehicles criteras by input properties or skipping properties");
                Console.WriteLine("7. Go back to main menu");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        var randomVehcileObject = CreateRandomVehicle();
                        currentGarage.addVehicle(randomVehcileObject);
                        break;
                    case "1":
                        garagehandler.AddVehicle(currentGarage);
                        break;
                    case "2":
                        garagehandler.RemoveVehicle(currentGarage);
                        break;
                    case "3":
                        currentGarage.printVehicles();
                        break;
                    case "4":
                        garagehandler.printVehiclesByType(currentGarage);
                        break;
                    case "5":
                        garagehandler.searchVehicleByRegisterNumber(currentGarage);
                        break;
                    case "6":
                        garagehandler.searchByVehicleProperty(currentGarage);
                        break;
                    case "7":
                        programRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            } while (programRun);
        }

        
        // Generates a randomzied Vehcile object
        public Vehicle CreateRandomVehicle()
        {
            Random rand = new Random();
            string[] colors = { "Red", "Blue", "Green", "Yellow", "Black", "White" };
            string[] carModels = { "Toyota", "Honda", "Ford", "BMW", "Volvo", "Subaru" };
            string[] motorcycleModels = { "Harley-Davidson", "Yamaha", "Honda", "Kawasaki", "Suzuki", "Ducati" , "BMW" };
            string[] airplaneModels = { "Harley-Davidson", "Boeing", "Airbus", "Cessna", "Gulfstream", "Embraer", "Saab" };
            string[] busModels = { "Scania", "Volvo", "Mercedes-Benz", "BMW", "MAN"};
            string[] boatModels = { "Nimbus ", "Hallberg-Rassy", "Nimbus", "Nord-Star", "Storebro", "Malö" };
            string[] years = { "2010", "2012", "2015", "2018", "2020", "2022" };

            int typeIndex = rand.Next(5); // Choose random type index
            switch (typeIndex)
            {
                case 0:
                    return new Car(RandomRegNum(), colors[rand.Next(colors.Length)], rand.Next(3, 6), carModels[rand.Next(carModels.Length)], years[rand.Next(years.Length)], "Gas");
                case 1:
                    return new Motorcycle(RandomRegNum(), colors[rand.Next(colors.Length)], 2, motorcycleModels[rand.Next(motorcycleModels.Length)], years[rand.Next(years.Length)], rand.NextDouble() * 30);
                case 2:
                    return new AirPlane(RandomRegNum(), colors[rand.Next(colors.Length)], 6, airplaneModels[rand.Next(airplaneModels.Length)], years[rand.Next(years.Length)], rand.Next(2, 6));
                case 3:
                    return new Bus(RandomRegNum(), colors[rand.Next(colors.Length)], 8, busModels[rand.Next(busModels.Length)], years[rand.Next(years.Length)], rand.Next(20, 50));
                case 4:
                    return new Boat(RandomRegNum(), colors[rand.Next(colors.Length)], 0, boatModels[rand.Next(boatModels.Length)], years[rand.Next(years.Length)], rand.NextDouble() * 30);
                default:
                    throw new InvalidOperationException("Invalid vehicle type.");
            }
        }

        //returns a randomized register number
        private string RandomRegNum()
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        // Creates a garage object by asking the user to fill in capacity, name, adress, city 
        //and adds it to a list object for garage class 
        public static void CreateGarageObject()
        {
            try
            {
                int capacity = InputHandler.GetIntegerInput("Enter capacity of parking lots in the garage: ");

                string garageName = InputHandler.GetStringInput("Enter the name of the garage:");

                string address = InputHandler.GetStringInput("Enter the address of the garage:");

                string city = InputHandler.GetStringInput("Enter the city of the garage:");

                //add the garage to the garageList in garageHandler 
                garagehandler.addGarageToList(capacity, garageName, address, city);

                Console.WriteLine("Garage created sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong when creating garage object: " + ex.Message);
            }
        }
    }

}