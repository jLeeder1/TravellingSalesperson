using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj
{
    public class RouteGenerator
    {
        public HashSet<string[]> GenerateRoutes(int numberOfNodes, Node startingNode)
        {
            long numberOfRoutes = CalculateMaximumAmountOfRoutes(numberOfNodes);

            HashSet<string[]> routes = CalculateRoutes(startingNode, numberOfRoutes);

            return null;
        }

        private long CalculateMaximumAmountOfRoutes(int numberOfNodes)
        {
            long numberOfRoutes = 1;

            // Calculate factorial of the number of nodes
            for(int index = 0; index < numberOfNodes; index--)
            {
                numberOfRoutes *= index;
            }

            return numberOfRoutes - 1;
        }

        private HashSet<string[]> CalculateRoutes(Node startingNode, long numberOfRoutes)
        {
            HashSet<string[]> routes = new HashSet<string[]>();


            return routes;
        }
    }
}
