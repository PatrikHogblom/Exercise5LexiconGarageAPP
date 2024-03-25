namespace Exercise5LexiconGarage.Vehicles
{
    public class AirPlane : Vehicle
    {
        private int _numberOfEngines; 
        public AirPlane(string registerNumber, string color, int totWheels, string model, string year, int numberOfEngines) : base(registerNumber, color, totWheels, model, year)
        {
            _numberOfEngines = numberOfEngines;
        }

        public override string Stats()
        {
            return base.Stats() + $"Number of engines: {_numberOfEngines}";
        }
    }
}