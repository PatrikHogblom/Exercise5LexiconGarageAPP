
using Exercise5LexiconGarage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercise5LexiconGarage.Garages
{
    /*
     Vad behöver vi i garage klassen? 
    1. skall vara generisk klass 
    2. skall ha en arrayen Vehicles samt dess kapacitet
    3. övriga properties/fields: Namn, adress, stad, totPlatser   
     
     */
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

        public Vehicle[] GetVehicles 
        {
            get
            {
                return Vehicles.Where(vehicle => vehicle != null).ToArray();
            }
        }


        public void addVehicle(T createdObject)
        {
            //find a empty slot in the Vehicles array
            int index = Array.FindIndex(Vehicles, vehicle => vehicle == null);

            if (index != -1)
            {
                Vehicles[index] = createdObject;
                Console.WriteLine($"Added {createdObject.RegisterNumber} to the Vehicles[]!");
            }
            else
            {
                Console.WriteLine("Garage is full!!!");
            }
        }

        public void printVehicles()
        {
            Console.WriteLine("------------Vehicles obj Array--------------");
            for (int i = 0; i < Vehicles.Length; i++)
            {
                //todo: might change this according to subclass type, i.e. every sub class have a unique "egenskap" 
                if (Vehicles[i] != null)
                {
                    Console.WriteLine($" VehicleType: {Vehicles[i].GetType().Name} registerNumber: {Vehicles[i].RegisterNumber}");
                    //todo: skapa en metod states() för skriva ut klassens variabler?
                }
            }
            Console.WriteLine("--------------------------------------------");
        }

        public void RemoveVehicleByRegisterNumber(string regNum)
        {
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i] != null)
                {
                    if (Vehicles[i].RegisterNumber.ToLower() == regNum.ToLower())
                    {
                        Vehicles[i] = null;
                        Console.WriteLine($"Removed {regNum} from the parking lot in the current garage.");
                        break;
                    }
                }

                if (i == Vehicles.Length-1) 
                {
                    Console.WriteLine($"{regNum} doesn't exist in parking lots ");
                }
            }
        }

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
                        Console.WriteLine($"{Vehicles[i].RegisterNumber}");
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


        /*public IEnumerable<T> FindVehicles(Func<T,bool> predicate)
        {
            return (IEnumerable<T>)Vehicles.Where((Func<Vehicle, bool>)predicate);
        }*/

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

        public Vehicle[] FilterByVehicleType(string inputSelectedType, Vehicle[] ResultFilter) => ResultFilter.Where(v => v != null && v.GetType().Name.ToLower() == inputSelectedType).ToArray();

        public Vehicle[] FilterByVehicleColor(string inputColor, Vehicle[] ResultFilter) => ResultFilter.Where(v => v != null && v.Color.ToLower() == inputColor).ToArray();

        public Vehicle[] FilterByVehicleRegNum(string inputRegNum, Vehicle[] ResultFilter) => ResultFilter.Where(v => v != null && v.RegisterNumber.ToLower() == inputRegNum).ToArray();

        public Vehicle[] FilterByNumWheels(int inputTotWheels, Vehicle[] ResultFilter) => ResultFilter.Where(v => v != null && v.TotWheels == inputTotWheels).ToArray();

        public Vehicle[] FilterByVehicleModel(string inputModel, Vehicle[] ResultFilter) => ResultFilter.Where(v => v != null && v.Model.ToLower() == inputModel).ToArray();

        public Vehicle[] FilterByVehicleYear(string inputYear, Vehicle[] ResultFilter) => ResultFilter.Where(v => v != null && v.Year.ToLower() == inputYear).ToArray();

        public Vehicle[] FilterByVehicle(string inputYear, Vehicle[] ResultFilter) => ResultFilter.Where(v => v != null && v.GetType().Name.ToLower() == inputYear).ToArray();
    }
}