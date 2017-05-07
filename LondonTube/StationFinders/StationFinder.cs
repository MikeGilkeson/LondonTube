using LondonTube.Graph;
using LondonTube.TubeMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonTube.StationFinders
{
    public class StationFinder
    {
        private LondonTubeMap _map;

        public StationFinder(LondonTubeMap map)
        {
            _map = map;
        }

        public List<string> FindFurtherestStations(string startStationName, int numberOfStops)
        {
            var startStation = _map.GetStation(startStationName);
            var stationsToMinimumStops = new Dictionary<string, int>();
            TravelNStops(startStation, numberOfStops, 0, ref stationsToMinimumStops);
            var stations = stationsToMinimumStops.Where(x => x.Value == numberOfStops).OrderBy(x => x.Key).Select(x => x.Key);
            return stations.ToList();
        }

        private void TravelNStops(GraphNode<string> startStation, int numberOfStationsToTravel, int currentCount, ref Dictionary<string, int> stationsToMinimumStops)
        {
            // check parameters
            if (stationsToMinimumStops.ContainsKey(startStation.Value))
            {
                if (stationsToMinimumStops[startStation.Value] > currentCount)
                    stationsToMinimumStops[startStation.Value] = currentCount;
            }
            else
                stationsToMinimumStops.Add(startStation.Value, currentCount);
            if (numberOfStationsToTravel < 1)
                return;
            // check null
            foreach (var neighbor in startStation.Neighbors)
            {
                if (!stationsToMinimumStops.ContainsKey(neighbor.Value) || stationsToMinimumStops[neighbor.Value] > currentCount)   // only need to recurse if the path doesn't exist or will be shorter
                    TravelNStops(neighbor as GraphNode<string>, numberOfStationsToTravel - 1, currentCount + 1, ref stationsToMinimumStops);
            }
        }
    }
}
