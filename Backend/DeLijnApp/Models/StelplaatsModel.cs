namespace DeLijnApp.Models
{
    public class StelplaatsModel
    {
        public string Stelplaats { get; set; }
        public BusModel[] Parking { get; set; }
        public BusModel[] Garage { get; set; }
    }
}
