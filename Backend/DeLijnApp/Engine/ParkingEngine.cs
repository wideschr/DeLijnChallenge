using DeLijnApp.Models;

namespace DeLijnApp.Engine
{
    public class ParkingEngine
    {
        private int _largeSpots = 4;
        private int _mediumSpots = 6;
        private int _smallSpots = 10;

        public StelplaatsModel ParkBuses(StelplaatsModel incoming)
        {
            var result = new StelplaatsModel();

            var large = incoming.Parking.Where(x => x.Type == BusType.GROOT).ToList();
            var medium = incoming.Parking.Where(x => x.Type == BusType.NORMAAL).ToList();
            var small = incoming.Parking.Where(x => x.Type == BusType.MINI).ToList();

            result.Garage.AddLarge(large);
            _largeSpots -= large.Count;
            result.Garage.AddLarge(medium.Take(_largeSpots * 2).ToList());
            if (_largeSpots < 0)
            {
                throw new ArgumentException("Incorrect number of parking spaces");
            }

            result.Garage.AddMedium(medium.Skip(_largeSpots * 2).Take(_mediumSpots).ToList());
            _mediumSpots -= medium.Count - _largeSpots * 2;

            if (_mediumSpots < 0)
            {
                throw new ArgumentException("Incorrect number of parking spaces");
            }
            result.Garage.AddMedium(small.Take(_mediumSpots * 2).ToList());
            result.Garage.AddSmall(small.Skip(_mediumSpots * 2).Take(_smallSpots).ToList());

            if (result.Garage.Mini?.Count > _smallSpots)
            {
                throw new ArgumentException("Incorrect number of parking spaces");
            }
            return result;
        }
    }
}
