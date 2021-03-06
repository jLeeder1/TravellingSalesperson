﻿using System;
using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj
{
    public static class DataDisplay
    {
        public static void PrintGraphOfNodes(Graph graph)
        {
            foreach (KeyValuePair<int, double[]> entry in graph.GraphOfNodes)
            {
                Console.WriteLine($"{System.Environment.NewLine}Node ID: {entry.Key}, Node Coordinates: {entry.Value[0]}, {entry.Value[1]}");
            }
        }

        public static void PrintRouteAndCalculation(int[] route, double costOfRoute)
        {
            string routePath = String.Empty;

            foreach (int nodeId in route)
            {
                routePath = $"{routePath} {nodeId}";
            }

            Console.WriteLine($"{System.Environment.NewLine}The route taken was {routePath} with a cost of {costOfRoute}");
        }

        public static void PrintDictionaryOfBestRoutes(Dictionary<int, Route> bestRoutes)
        {
            foreach(KeyValuePair<int, Route> entry in bestRoutes)
            {
                string bestRouteStr = RouteToString(entry.Value.RouteIds.ToList());
                Console.WriteLine($"{System.Environment.NewLine}Generation number ID: {entry.Key}, Best Route: {bestRouteStr}, Best Cost: {entry.Value.RouteCost}");
            }
        }

        /*
         * This should not be here, too much logic and not enough display
         */
        public static void PrintBestRouteOverall(Dictionary<int, Route> bestRoutes)
        {
            List<int> bestRoute = new List<int>();
            double bestCost = double.MaxValue;
            int generationNumer = 0;

            foreach (KeyValuePair<int, Route> entry in bestRoutes)
            {
                if(entry.Value.RouteCost < bestCost)
                {
                    bestCost = entry.Value.RouteCost;
                    bestRoute.Clear();
                    bestRoute.AddRange(entry.Value.RouteIds.ToList());
                    generationNumer = entry.Key;
                }
            }
            string bestRouteStr = RouteToString(bestRoute);

            Console.WriteLine($"{System.Environment.NewLine}Generation number ID: {generationNumer}, Best Route: {bestRouteStr}, Best Cost: {bestCost}");
        }

        private static string RouteToString(List<int> route)
        {
            string stringRoute = string.Empty;

            route.ToList().ForEach(i => stringRoute = $"{stringRoute} {i}");

            return stringRoute;
        }
    }
}
