using System;

namespace TravellingSalespersonProj
{
    public class RouteEvaluator
    {
        public float CalculateCostOfSingleRoute(int[] route, Graph graph)
        {
            float costOfRoute = 0.0f;

            for(int index = 0; index <= route.Length -1; index++)
            {
                if(index < route.Length - 2 && graph.GraphOfNodes.ContainsKey(index))
                {
                    float[] coordinatesToCompare = GetCoordinatesToCompare(route[index], route[index + 1], graph);
                    costOfRoute += graph.CalculateCostOfEdge(coordinatesToCompare);
                }
            }

            return costOfRoute;
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
