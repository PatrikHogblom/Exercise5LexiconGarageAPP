
using Exercise5LexiconGarage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public Vehicle[] GetVehicles 
        {
            get
            {
                return Vehicles.Where(vehicle => vehicle != null).ToArray();
            }
        }


        public void addVehicle(T createdObject)
        {
            //todo: check that the object/register number is no already exist in the garage?
            int index = Array.FindIndex(Vehicles, vehicle => vehicle == null);

            bool RegNumExists = searchVehicleByRegisterNumber(createdObject.RegisterNumber);
            if (RegNumExists == true)
            {
                Console.WriteLine($"The registernumber {createdObject.RegisterNumber} already exist, please restart process and input correct registernumber");
                return;
            }
            else
            {
                if (index != -1)
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

        //todo: create so this returns a bool or the garage instead, so we can test the method later?
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

        //todo: return true or false ehen testing later? 
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

        //public T[] FilterByVehicle(string inputYear, T[] ResultFilter) => ResultFilter.Where(v => v != null && v.GetType().Name.ToLower() == inputYear).ToArray();
    }
}