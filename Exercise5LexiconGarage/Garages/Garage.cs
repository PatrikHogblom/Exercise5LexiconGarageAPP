﻿
namespace Exercise5LexiconGarage.Garages
{
    /*
     Vad behöver vi i garage klassen? 
    1. skall vara generisk klass 
    2. skall ha en arrayen Vehicles samt dess kapacitet
    3. övriga properties/fields: garageID, Namn, adress, stad, totPlatser   
     
     */
    internal class Garage
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
    }
}