namespace Exercise5LexiconGarage.Vehicles
{
    class Bus : Vehicle
    {
        private int numberOfSeats;
        public Bus(string registerNumber, string color, int totWheels, string model, string year, int numberOfSeats) : base(registerNumber, color, totWheels, model, year)
        {
            this.numberOfSeats = numberOfSeats;
        }
    }
}