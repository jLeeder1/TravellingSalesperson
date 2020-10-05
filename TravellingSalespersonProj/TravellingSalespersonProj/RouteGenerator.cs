using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellingSalespersonProj
{
    public class RouteGenerator
    {
        public List<string[]> GenerateRoutes(int numberOfNodes, float startingNode)
        {
            long numberOfRoutes = CalculateMaximumAmountOfRoutes(numberOfNodes);
            float[] possibleNodes = CreateListOfPossibleNodes(numberOfNodes);

            List<string[]> routes = CalculateRoutes(startingNode, numberOfRoutes, possibleNodes);

            return null;
        }

        private long CalculateMaximumAmountOfRoutes(int numberOfNodes, bool isAnchored = true)
        {
            long numberOfRoutes = 1;

            // Calculate factorial of the number of nodes
            for(int index = 0; index < numberOfNodes; index--)
            {
                numberOfRoutes *= index;
            }

            if (isAnchored)
            {
                numberOfRoutes /= numberOfNodes;
            }

            return numberOfRoutes - 1;
        }

        private float[] CreateListOfPossibleNodes(int numberOfNodes)
        {
            float[] possibleNodes = new float[numberOfNodes];

            for(int index = 0; index <= numberOfNodes; index++)
            {
                possibleNodes[index] = index;
            }

            return possibleNodes;
        }

        private List<string[]> CalculateRoutes(float startingNode, long numberOfRoutes, float[] possibleNodes)
        {
            List<string[]> routes = new List<string[]>();

            float[] currentRoute = new float[possibleNodes.Length];
            currentRoute[0] = startingNode;
            float[] lastRoute = new float[possibleNodes.Length];
            float[] nodesVisitedThisIteration = new float[possibleNodes.Length];

            for(int outerIndex = 0; outerIndex < possibleNodes.Length - 1; outerIndex++)
            {

            }

            lastRoute = currentRoute;

            return routes;
        }

        private float[] PopulateFirstRoute(float startingNode, int numberOfNodes)
        {
            float[] firstRoute = new float[numberOfNodes];

            for (int index = 0; index < numberOfNodes - 1; index++)
            {

            }

            return firstRoute;
        }
    }
}
