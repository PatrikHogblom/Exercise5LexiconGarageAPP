namespace Exercise5LexiconGarage.Vehicles
{

    public abstract class Vehicle : IVehicle
    {
        private string _registerNumber;
        private string _color;
        private string _totWheels;
        private string _model;
        private string _year;

        public Vehicle(string registerNumber, string color, string totWheels, string model, string year)
        {
            _registerNumber = registerNumber;
            _color = color;
            _totWheels = totWheels;
            _model = model;
            _year = year;
        }

        public string RegisterNumber { get => _registerNumber; set => _registerNumber = value; }
        public string Color { get => _color; set => _color = value; }
        public string TotWheels { get => _totWheels; set => _totWheels = value; }
        public string Model { get => _model; set => _model = value; }
        public string Year { get => _year; set => _year = value; }
    }
}