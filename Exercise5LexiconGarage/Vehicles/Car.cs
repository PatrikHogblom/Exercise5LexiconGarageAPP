namespace Exercise5LexiconGarage.Vehicles
{
    class Car : Vehicle
    {
        private string _fuelType;  
        public Car(string registerNumber, string color, string totWheels, string model, string year, string fuelType) : base(registerNumber, color, totWheels, model, year)
        {
            _fuelType = fuelType;
        }
    }
}