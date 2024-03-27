namespace Exercise5LexiconGarage.Vehicles
{
    public class Car : Vehicle
    {
        private string _fuelType;  
        public Car(string registerNumber, string color, int totWheels, string model, string year, string fuelType) : base(registerNumber, color, totWheels, model, year)
        {
            _fuelType = fuelType;
        }

        public override string Stats()
        {
            return base.Stats() + $"Fuel: {_fuelType.ToLower()}";
        }
    }
}