
namespace DeLijnApp.Models
{
    public class GarageModel
    {
        public GarageModel()
        {
            Groot = new List<BusModel>();
            Normaal = new List<BusModel>();
            Mini = new List<BusModel>();
        }

        public List<BusModel>? Groot { get; set; }
        public List<BusModel>? Normaal { get; set; }
        public List<BusModel>? Mini { get; set; }

        public void AddLarge(List<BusModel> buses)
        {
            Groot.AddRange(buses);
        }

        public void AddMedium(List<BusModel> buses)
        {
            Normaal.AddRange(buses);
        }

        public void AddSmall(List<BusModel> buses)
        {
            Mini.AddRange(buses);
        }
    }
}
