
using Exercise5LexiconGarage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise5LexiconGarage.Garages
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private Vehicle[] Vehicles;
        private int totVehicleCapacity;
        private string NameGarage;
        private string Address;
        private string City;

        public Garage(int capacity, string nameGarage, string address, string city)
        {
            totVehicleCapacity = capacity;
            Vehicles = new Vehicle[totVehicleCapacity];
            NameGarage = nameGarage;
            Address = address;
            City = city;
        }

        public int GarageCapacity
        {
            get { return totVehicleCapacity; }
            //set {  totVehicleCapacity = value; } 
        }
        public string GarageName
        {
            get { return NameGarage; }
            set { NameGarage = value; }
        }
        public string GarageAddress
        {
            get { return Address; }
            set { Address = value; }
        }

        public string GarageCity
        {
            get { return City; }
            set { City = value; }
        }

        //returns a array of vehciles, skips the null values(i.e. unparked lots)
        public Vehicle[] GetVehicles 
        {
            get
            {
                return Vehicles.Where(vehicle => vehicle != null).ToArray();
            }
        }

        //method to park a vehcil 
        public void addVehicle(T createdObject)
        {
            int index = Array.FindIndex(Vehicles, vehicle => vehicle == null);

            bool RegNumExists = searchVehicleByRegisterNumber(createdObject.RegisterNumber);
            if (RegNumExists == true)//if reg number exists then return to submenu,
            {
                Console.WriteLine($"The registernumber {createdObject.RegisterNumber} already exist, please restart process and input correct registernumber");
                return;
            }
            else
            {
                if (index != -1)//if garage is not full, you can opark vehciles else tell the user the garage is full
                {
                    Vehicles[index] = createdObject;
                    Console.WriteLine($"Parked {createdObject.RegisterNumber} to the garage!");
                }
                else
                {
                    Console.WriteLine("Garage is full!!!");
                }
            }
        }
        //prints out all parked vehciles 
        public void printVehicles()
        {
            Console.WriteLine("------------Vehicles obj Array--------------");

            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] != null)
                {
                    Console.WriteLine(Vehicles[i].Stats());
                }
            }
            Console.WriteLine("--------------------------------------------");
        }

        //removes/unpark vehciles
        public void RemoveVehicleByRegisterNumber(string regNum)
        {
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] != null)
                {
                    if (Vehicles[i].RegisterNumber.ToLower() == regNum.ToLower())//if reg number exists, unpark the vehcile bu setting the spot to null
                    {
                        Vehicles[i] = null;
                        Console.WriteLine($"Removed {regNum} from the parking lot in the current garage.");
                        break;
                    }
                }

                if (i == Vehicles.Length-1) //if register number doesnt exist in parkinglots  
                {
                    Console.WriteLine($"{regNum} doesn't exist in parking lots ");
                }
            }
        }
        //returns true if searched registernumber exists in the garage or false if it doen't exist 
        public bool searchVehicleByRegisterNumber(string regNum)
        {
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] != null)
                {
                    if (Vehicles[i].RegisterNumber.ToLower() == regNum.ToLower())
                    {
                        return true;//return true if we find vehicle 
                    }
                }
            }
            return false;//returns false if we don't find the vehicle
        }

        //lists all vechicles by selected Type
        public void searchVehiclesForAType(string selectedSubclass)
        {
            Console.WriteLine($"Vehciles of type {selectedSubclass} that exists in current garage are: ");
            Console.WriteLine($"----------------------------------------------");
            bool typeExists = false;
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] != null)
                {
                    if (Vehicles[i].GetType().Name.ToString() == selectedSubclass)
                    {
                        Console.WriteLine($"{Vehicles[i].Stats()}");
                        typeExists = true;
                    }
                }
            }
            Console.WriteLine($"-----------------------------------------------");
            if (typeExists == false)
            {
                Console.WriteLine($"{selectedSubclass} doesn't exist in parking lots ");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in Vehicles)
            {
                if (vehicle != null)
                {
                    yield return (T)vehicle;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] FilterByVehicleType(string inputSelectedType, T[] ResultFilter) => ResultFilter.Where(v => v != null && v.GetType().Name.ToLower() == inputSelectedType).ToArray();

        public T[] FilterByVehicleColor(string inputColor, T[] ResultFilter) => ResultFilter.Where(v => v != null && v.Color.ToLower() == inputColor.ToLower()).ToArray();

        public T[] FilterByVehicleRegNum(string inputRegNum, T[] ResultFilter) => ResultFilter.Where(v => v != null && v.RegisterNumber.ToLower() == inputRegNum.ToLower()).ToArray();

        public T[] FilterByNumWheels(int inputTotWheels, T[] ResultFilter) => ResultFilter.Where(v => v != null && v.TotWheels == inputTotWheels).ToArray();

        public T[] FilterByVehicleModel(string inputModel, T[] ResultFilter) => ResultFilter.Where(v => v != null && v.Model.ToLower() == inputModel.ToLower()).ToArray();

        public T[] FilterByVehicleYear(string inputYear, T[] ResultFilter) => ResultFilter.Where(v => v != null && v.Year.ToLower() == inputYear).ToArray();

    }
}