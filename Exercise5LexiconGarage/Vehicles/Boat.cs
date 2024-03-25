namespace Exercise5LexiconGarage.Vehicles
{
    class Boat : Vehicle
    {
        private double _boatLength;
        public Boat(string registerNumber, string color, int totWheels, string model, string year, double boatLength) : base(registerNumber, color, totWheels, model, year)
        {
            _boatLength = boatLength;
        }

        public override string Stats()
        {
            return base.Stats() + $"Boat length: {_boatLength} m";
        }
    }
}