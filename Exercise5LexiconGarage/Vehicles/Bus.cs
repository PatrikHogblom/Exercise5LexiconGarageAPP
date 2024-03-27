namespace Exercise5LexiconGarage.Vehicles
{
    public class Bus : Vehicle
    {
        private int _numberOfSeats;
        public Bus(string registerNumber, string color, int totWheels, string model, string year, int numberOfSeats) : base(registerNumber, color, totWheels, model, year)
        {
            _numberOfSeats = numberOfSeats;
        }

        public override string Stats()
        {
            return base.Stats() + $"Number of seats: {_numberOfSeats}";
        }
    }
}