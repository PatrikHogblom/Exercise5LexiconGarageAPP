namespace Exercise5LexiconGarage.Vehicles
{
    class Motorcycle : Vehicle
    {
        private double _cylinderVolume;

        public Motorcycle(string registerNumber, string color, int totWheels, string model, string year, double cylinderVolume) : base(registerNumber, color, totWheels, model, year)
        {
            _cylinderVolume = cylinderVolume;
        }
    }
}