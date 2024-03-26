using System.Reflection;
using System.Xml.Linq;

namespace Exercise5LexiconGarage.Vehicles
{

    public abstract class Vehicle : IVehicle
    {
        private string _registerNumber;
        private string _color;
        private int _totWheels;
        private string _model;
        private string _year;

        public Vehicle(string registerNumber, string color, int totWheels, string model, string year)
        {
            _registerNumber = registerNumber;
            _color = color;
            _totWheels = totWheels;
            _model = model;
            _year = year;
        }

        public string RegisterNumber { get => _registerNumber; set => _registerNumber = value; }
        public string Color { get => _color; set => _color = value; }
        public int TotWheels { get => _totWheels; set => _totWheels = value; }
        public string Model { get => _model; set => _model = value; }
        public string Year { get => _year; set => _year = value; }

        public virtual string Stats()
        {
            string textValue = string.Empty;
            textValue += $"Vehicle Type: {GetType().Name}  ";
            textValue += $"Register Number: {_registerNumber}  ";
            textValue += $"Color: {_color}  ";
            textValue += $"Total Wheels: {_totWheels}  ";
            textValue += $"Model: {_model}  ";
            textValue += $"Year: {_year}  ";

            return textValue;
        }

    }
}