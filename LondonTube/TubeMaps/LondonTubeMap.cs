using LondonTube.Graph;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LondonTube.TubeMaps
{
    public class LondonTubeMap
    {
        private static readonly LondonTubeMap _instance = new LondonTubeMap();   // instantiate at startup so the map can me ready sooner

        private Graph<string> _graphMap = new Graph<string>();
        private Dictionary<string, GraphNode<string>> _stationNodesAdded = new Dictionary<string, GraphNode<string>>(); // store the stations in a dictionary for faster lookups
        private AutoResetEvent _isLoaded = new AutoResetEvent(false);
        private bool _isLoading = false;

        private LondonTubeMap()
        {
            new Thread(LoadMap).Start();    // load in a background thread so we don't block the UI or startup
        }

        public static LondonTubeMap Instance
        {
            get { return _instance; }
        }

        private void LoadMap()
        {
            if (_isLoading)
                return;
            // exception handling
            // event when done
            _isLoading = true;
            using (var parser = new TextFieldParser(@"Data\London tube lines.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    // check that there are 3 fields
                    if (fields[0] == "Tube Line")
                        continue;   // don't need to do anything with header row
                    // do something with line

                    _graphMap.AddUndirectedEdge(GetOrAddStation(fields[1]),
                                                GetOrAddStation(fields[2]),
                                                0);
                }
            }
            _isLoading = false;
            _isLoaded.Set();
        }

        private GraphNode<string> GetOrAddStation(string stationName)
        {
            var station = GetStation(stationName);
            if (station != null)
                return station;
            station = new GraphNode<string>(stationName);
            _stationNodesAdded.Add(stationName, station);
            _graphMap.AddNode(station);
            return station;
        }
        public GraphNode<string> GetStation(string stationName)
        {
            return _stationNodesAdded.ContainsKey(stationName) ? _stationNodesAdded[stationName] : null;
        }

        public List<string> GetAllStations()
        {
            _isLoaded.WaitOne();
            return _stationNodesAdded.Keys.ToList();
        }
    }
}
