namespace Exercise5LexiconGarage.Vehicles
{
    interface IVehicle
    {
        string RegisterNumber { get; set; }
        string Color { get; set;}
        int TotWheels { get; set;}
        string Model { get; set;}
        string Year { get; set;}

        string Stats();
    }
}