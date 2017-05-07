using LondonTube.StationFinders;
using LondonTube.TubeMaps;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LondonTube
{
    public partial class TesterForm : Form
    {
        public TesterForm()
        {
            InitializeComponent();
            _stations.Items.AddRange(LondonTubeMap.Instance.GetAllStations().ToArray());
            _stations.Text = "East Ham";
        }

        private void _calculateButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_stations.Text))
            {
                MessageBox.Show("Please select a station.");
                _stations.Show();
                return;
            }
            var stationFinder = new StationFinder(LondonTubeMap.Instance);
            _stationsFound.Items.Clear();
            _stationsFound.Items.AddRange(stationFinder.FindFurtherestStations(_stations.Text, (int)_numberOfStops.Value).ToArray());
            //var startStation = stationsNodesAdded.FirstOrDefault(item => item.Key == "East Ham");
            //var stationsToMinimumStops = new Dictionary<string, int>();
            //TravelNStops(startStation.Value, 5, 0, ref stationsToMinimumStops);
        }

        private void TravelNStops(Graph.GraphNode<string> startStation, int numberOfStationsToTravel, int currentCount, ref Dictionary<string, int> stationsToMinimumStops)
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
                //if (!stationsToMinimumStops.ContainsKey(neighbor.Value))
                    TravelNStops(neighbor as Graph.GraphNode<string>, numberOfStationsToTravel - 1, currentCount + 1, ref stationsToMinimumStops);
            }
        }
    }
}
