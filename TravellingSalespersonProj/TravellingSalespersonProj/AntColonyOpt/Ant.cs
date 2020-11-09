using System.Collections.Generic;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public class Ant
    {
        public Route AntRoute { get; set; }

        private readonly int startEndCity;

        public Ant(int startEndCity)
        {
            this.startEndCity = startEndCity;
        }

        public void ConstructGreedyRoute(Graph graph, RouteEvaluator routeEvaluator)
        {
            List<int> visitedCities = new List<int>();
            List<int> currentRoute = new List<int>();

            visitedCities.Add(startEndCity);
            currentRoute.Add(startEndCity);

            while(currentRoute.Count <= graph.GraphOfNodes.Count)
            {
                currentRoute.Add(graph.GetClosestCity(currentRoute.Count - 1, visitedCities));
            }

            currentRoute.Add(startEndCity);
            int[] currentRouteArray = currentRoute.ToArray();

            double routeCost = routeEvaluator.CalculateCostOfSingleRoute(currentRouteArray, graph);
            AntRoute = new Route(currentRouteArray, routeCost);
        }

        private int ChooseNextCityToVisit(PheromoneLookup pheromoneLookup, RouteEvaluator routeEvaluator)
        {
            List<int> visitedCities = new List<int>();
            List<int> currentRoute = new List<int>();

            // Pheremones on edge i -> j

            // Cost of edge i -> j



            return 0;
        }
    }
}
