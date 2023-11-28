namespace DeLijnApp.Models
{
    public class StelplaatsModel
    {
        public StelplaatsModel()
        {
            Garage = new GarageModel();
        }

        public string Stelplaats { get; set; }
        public BusModel[] Parking { get; set; }
        public GarageModel Garage { get; set; }
    }
}
