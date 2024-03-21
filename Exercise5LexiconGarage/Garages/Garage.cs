﻿
using Exercise5LexiconGarage.Vehicles;

namespace Exercise5LexiconGarage.Garages
{
    /*
     Vad behöver vi i garage klassen? 
    1. skall vara generisk klass 
    2. skall ha en arrayen Vehicles samt dess kapacitet
    3. övriga properties/fields: garageID, Namn, adress, stad, totPlatser   
     
     */
    public class Garage
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
            get {  return totVehicleCapacity; } 
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

        public void addVehicle(AirPlane airPlane)
        {
            //find a empty slot in the Vehicles array
            int index = Array.FindIndex(Vehicles, vehicle => vehicle == null);

            if (index != -1)
            {
                Vehicles[index] = airPlane;
                Console.WriteLine($"Added {airPlane.RegisterNumber} to the Vehicles[]!");
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
                if (Vehicles[i] != null)
                {
                    Console.WriteLine(Vehicles[i].RegisterNumber);
                }
            }
            Console.WriteLine("--------------------------------------------");
        }


        //add to the vehicle class 
    }
}