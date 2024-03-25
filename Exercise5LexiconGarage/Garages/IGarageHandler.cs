using Exercise5LexiconGarage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5LexiconGarage.Garages
{
    public interface IGarageHandler
    {
        void addGarageToList(int capacity, string name, string address, string city);
        void AddVehicle(Garage<Vehicle> garage);
        void RemoveVehicle(Garage<Vehicle> currentGarage);
        void printVehiclesByType(Garage<Vehicle> currentGarage);
        void searchVehicleByRegisterNumber(Garage<Vehicle> currentGarage);
        void searchByVehicleProperty(Garage<Vehicle> currentGarage);

    }
}
