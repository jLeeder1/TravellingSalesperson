using System;
using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.GenericTSP;

namespace TravellingSalespersonProj.LocalSearchTutorial
{
    public class LocalSearch
    {
        private readonly RouteEvaluator routeEvaluator;
        private readonly TourFormatter tourFormatter;

        public LocalSearch()
        {
            routeEvaluator = new RouteEvaluator();
            tourFormatter = new TourFormatter();
        }

        public Route RunLocalSearch(Graph graph, int[] initialRoute)
        {
            List<int[]> listOfNeighbourhoods = GetAllTwoOptNeighbourhoods(initialRoute);
            Route bestRoute = new Route(initialRoute, int.MaxValue);
            bool isViableSearchSpace = true;

            while (isViableSearchSpace)
            {
                Route currentRoute = FindBestTourInNeighbourhood(listOfNeighbourhoods, graph);

                if (currentRoute.RouteCost < bestRoute.RouteCost)
                {
                    bestRoute = currentRoute;
                }
                else
                {
                    isViableSearchSpace = false;
                }

                listOfNeighbourhoods.Clear();
                listOfNeighbourhoods = GetAllTwoOptNeighbourhoods(bestRoute.RouteIds);
            }

            return bestRoute;
        }

        private List<int[]> GetAllTwoOptNeighbourhoods(int[] initialRoute)
        {
            List<int[]> listOfNeighbourhoods = new List<int[]>();

            int[] formatedRoute = tourFormatter.RemoveStartAndEndNodeToRoute(initialRoute);

            for (int index = 0; index <= formatedRoute.Length - 2; index++)
            {
                for (int secondIndex = index + 1; secondIndex <= formatedRoute.Length - 1; secondIndex++)
                {
                    int[] swappedRoute = TwoOptSwap(formatedRoute, index, secondIndex);
                    listOfNeighbourhoods.Add(tourFormatter.AddStartAndEndNodeToRoute(initialRoute[0], swappedRoute));
                }
            }
            return listOfNeighbourhoods;
        }

        private void TESTMETHOD(List<int[]> test)
        {
            foreach(int[] route in test)
            {
                string routeString = string.Empty;
                for(int i = 0; i <= route.Length - 1; i++)
                {
                    routeString += route[i].ToString() + " ";
                }
                Console.WriteLine(routeString);
            }
        }

        private int[] TwoOptSwap(int[] route, int index, int secondIndex)
        {
            List<int> routeToReturn = new List<int>();

            for(int i = 0; i <= index -1; i++)
            {
                routeToReturn.Add(route[i]);
            }

            for (int i = secondIndex; i >= index; i--)
            {
                routeToReturn.Add(route[i]);
            }

            for (int i = secondIndex + 1; i <= route.Length -1; i++)
            {
                routeToReturn.Add(route[i]);
            }

            return routeToReturn.ToArray();
        }

        private Route FindBestTourInNeighbourhood(List<int[]> routes, Graph graph)
        {
            int[] bestRoute = new int[routes.ElementAt(0).Length];
            float bestCost = 0;

            foreach (int[] route in routes)
            {
                float routeCost = routeEvaluator.CalculateCostOfSingleRoute(route, graph);

                if(bestCost == 0 || routeCost < bestCost)
                {
                    bestCost = routeCost;
                    bestRoute = route;
                }
            }

            return new Route(bestRoute, bestCost);
        }
    }
}
