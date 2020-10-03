using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravellingSalespersonProj
{
    public class RouteGenerator
    {
        public List<string[]> GenerateRoutes(int numberOfNodes, string startingNode)
        {
            long numberOfRoutes = CalculateMaximumAmountOfRoutes(numberOfNodes);
            List<string> possibleNodes = CreateListOfPossibleNodes(numberOfNodes);

            List<string[]> routes = CalculateRoutes(startingNode, numberOfRoutes, possibleNodes);

            return null;
        }

        // Pass in or calculate all possible nodes (probably has to be a list)
        // add starting node to beginning of arrayToReturn
        // remove random element of list and add to array
        // Add starting node to end of arrayToReturn

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

        private List<string> CreateListOfPossibleNodes(int numberOfNodes)
        {
            List<string> possibleNodes = new List<string>();

            for(int index = 1; index <= numberOfNodes; index++)
            {
                possibleNodes.Add(ConvertIntToString.Convert(index));
            }

            return possibleNodes;
        }

        private List<string[]> CalculateRoutes(string startingNode, long numberOfRoutes, List<string> possibleNodes)
        {
            List<string[]> routes = new List<string[]>();

            // Array for single route
            string[] route = new string[possibleNodes.Count+1];
            route[0] = possibleNodes.ElementAt(0);
            possibleNodes.RemoveAt(0);
            Random random = new Random();

            while(routes.Count < numberOfRoutes)
            {/*
                for(int index = 0; index < possibleNodes)
                {
                    int randomNum = random.Next(possibleNodes.Count);
                    if (possibleNodes.ElementAt(randomNum) != null)
                    {
                        route[route.Length - 1] = possibleNodes.ElementAt(randomNum);
                        possibleNodes.RemoveAt(randomNum);
                    }

                    routes.Add(route);
                } */
            }

            return routes;
        }
    }
}
