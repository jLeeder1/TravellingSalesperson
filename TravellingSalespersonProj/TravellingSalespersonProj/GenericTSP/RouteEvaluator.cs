using System;

namespace TravellingSalespersonProj
{
    public class RouteEvaluator
    {
        public double CalculateCostOfSingleRoute(int[] route, Graph graph)
        {
            double costOfRoute = 0.0f;

            for(int index = 0; index <= route.Length -1; index++)
            {
                if(index < route.Length - 2 && graph.GraphOfNodes.ContainsKey(index))
                {
                    double[] coordinatesToCompare = GetCoordinatesToCompare(route[index], route[index + 1], graph);
                    costOfRoute += CalculateCostOfEdge(coordinatesToCompare);
                }
            }

            return costOfRoute;
        }

        /*
         * Format: [originx, originy, destinationx, destinationy]
         */
        public double CalculateCostOfEdge(double[] coordinates)
        {
            double xBxA = Math.Pow(coordinates[2] - coordinates[0], 2);
            double yByA = Math.Pow(coordinates[3] - coordinates[1], 2);
            double sqrRoot = xBxA + yByA;

            sqrRoot = Math.Sqrt(sqrRoot);
            return sqrRoot;
        }

        private double[] GetCoordinatesToCompare(int startingNode, int destinationNode, Graph graph)
        {
            double[] coordinatesToCompare = new double[4];

            graph.GraphOfNodes[startingNode].CopyTo(coordinatesToCompare, 0);
            graph.GraphOfNodes[destinationNode].CopyTo(coordinatesToCompare, 2);

            return coordinatesToCompare;
        }
    }
}
