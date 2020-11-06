using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TravellingSalespersonProj
{
    public class Graph
    {
        // Stores the graph in the format: NodeID, [NodeXPos, NodeYPos]
        public Dictionary<int, float[]> GraphOfNodes { get; set; }

        private readonly RouteEvaluator routeEvaluator;

        public Graph()
        {
            GraphOfNodes = new Dictionary<int, float[]>();
            routeEvaluator = new RouteEvaluator();
        }

        public void AddNodeToGraph(int nodeID, float[] nodeCoordinates)
        {
            if (!GraphOfNodes.ContainsKey(nodeID))
            {
                GraphOfNodes.Add(nodeID, nodeCoordinates);
            }
        }

        public void PopulateGraphWithDefaultValues()
        {
            // Node node 0 (A) had coordinate 0,0 with y traveling downwards with positive values
            // Note this isn't exactly the example
            float[,] defaultGraph =  new float[,]
            {
                { 0, 0, 0 },
                { 1, 20, 0 },
                { 2, 0, 42 },
                { 3, 12, 42 }
            };

            for(int index = 0; index < defaultGraph.GetLength(0); index++)
            {
                float[] coordinates = new float[] { defaultGraph[index, 1], defaultGraph[index, 2] };
                AddNodeToGraph(Convert.ToInt32(defaultGraph[index, 0]), coordinates);
            }
        }

        public int GetClosestCity(int currentCity, List<int> visitedCities)
        {
            int closestCity = int.MaxValue;
            float lowestCostEdge = float.MaxValue;

            float[] currentCityCoordinates = GraphOfNodes[currentCity];

            foreach (KeyValuePair<int, float[]> node in GraphOfNodes)
            {
                if(node.Key == currentCity || visitedCities.Contains(node.Key))
                {
                    continue;
                }

                List<float> coordinatesToCompare = new List<float>();
                coordinatesToCompare.AddRange(currentCityCoordinates);
                coordinatesToCompare.AddRange(node.Value);

                float costOFCurrentEdge = routeEvaluator.CalculateCostOfEdge(coordinatesToCompare.ToArray());

                if(costOFCurrentEdge < lowestCostEdge)
                {
                    lowestCostEdge = costOFCurrentEdge;
                    closestCity = node.Key;
                }
            }

            return closestCity;
        }
    }
}
