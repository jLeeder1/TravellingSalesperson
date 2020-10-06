using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj
{
    public class RouteEvaluator
    {
        public float CalculateCostOfSingleRoute(int[] route, Graph graph)
        {
            float costOfRoute = 0.0f;

            for(int index = 0; index < route.Length -1; index++)
            {
                if(index < route.Length - 2)
                {
                    float[] coordinatesToCompare = GetCoordinatesToCompare(route[index], route[index + 1], graph);
                    costOfRoute += CalculateCostOfEdge(coordinatesToCompare);
                }
            }

            return costOfRoute;
        }

        private float CalculateCostOfEdge(float[] coordinates)
        {
            float xCost = coordinates[0] + coordinates[2];
            float yCost = coordinates[1] + coordinates[3];

            return xCost + yCost;
        }

        private float[] GetCoordinatesToCompare(int startingNode, int destinationNode, Graph graph)
        {
            float[] coordinatesToCompare = new float[4];

            graph.GraphOfNodes[startingNode].CopyTo(coordinatesToCompare, 0);
            graph.GraphOfNodes[destinationNode].CopyTo(coordinatesToCompare, 2);

            return coordinatesToCompare;
        }
    }
}
