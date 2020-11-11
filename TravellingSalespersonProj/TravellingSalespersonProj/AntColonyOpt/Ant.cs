using System;
using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public class Ant
    {
        public Route AntRoute { get; set; }

        public List<int> VisitedCities { get; set; }
        public List<int> CurrentRoute { get; set; }

        private readonly Random random;

        public Ant()
        {
            VisitedCities = new List<int>();
            CurrentRoute = new List<int>();
            random = new Random();
        }

        public void ConstructGreedyRoute(Graph graph, RouteEvaluator routeEvaluator)
        {
            int startEndCity = InitialiseFirstCity(graph);

            while(CurrentRoute.Count <= graph.GraphOfNodes.Count)
            {
                CurrentRoute.Add(graph.GetClosestCity(CurrentRoute.Count - 1, VisitedCities));
            }

            CurrentRoute.Add(startEndCity);
            int[] CurrentRouteArray = CurrentRoute.ToArray();

            double routeCost = routeEvaluator.CalculateCostOfSingleRoute(CurrentRouteArray, graph);
            AntRoute = new Route(CurrentRouteArray, routeCost);
        }

        public Route WalkRoute(PheromoneLookup pheromoneLookup, RouteEvaluator routeEvaluator, Graph graph)
        {
            int startEndCity = InitialiseFirstCity(graph);

            while (CurrentRoute.Count <= graph.GraphOfNodes.Count)
            {
                int city = ChooseNextCityToVisit(pheromoneLookup, routeEvaluator, graph);
                CurrentRoute.Add(city);
                VisitedCities.Add(city);
            }

            CurrentRoute.Add(startEndCity);

            AntRoute = new Route(CurrentRoute.ToArray(), double.MaxValue);
            return AntRoute;
        }

        public void ClearRoutes()
        {
            VisitedCities.Clear();
            CurrentRoute.Clear();
        }

        // Trash programming right here
        private int InitialiseFirstCity(Graph graph)
        {
            int randomStartCity = random.Next(1, graph.GraphOfNodes.Count + 1);
            CurrentRoute.Add(randomStartCity);
            VisitedCities.Add(randomStartCity);

            return randomStartCity;
        }

        private int ChooseNextCityToVisit(PheromoneLookup pheromoneLookup, RouteEvaluator routeEvaluator, Graph graph)
        {
            int currentCity = CurrentRoute.Count - 1;
            List<double> componentProducts = new List<double>();
            List<int> citiesBeingConsideredToTravelTo = new List<int>();

            for (int cityToConsiderTravellingTo = 1; cityToConsiderTravellingTo <= graph.GraphOfNodes.Count; cityToConsiderTravellingTo++)
            {
                if(VisitedCities.Contains(cityToConsiderTravellingTo))
                {
                    continue;
                }
                citiesBeingConsideredToTravelTo.Add(cityToConsiderTravellingTo);

                double pheremoneComponent = Math.Pow(pheromoneLookup.GetPheromoneLevelForEdge(new int[] { currentCity, cityToConsiderTravellingTo }), ACOConstants.ALPHA_PHEROMONE_IMPORTANCE);
                double edgeComponent = Math.Pow(routeEvaluator.CalculateCostOfEdge(new int[] { currentCity, cityToConsiderTravellingTo }, graph), ACOConstants.BETA_EDGE_IMPORTANCE);

                componentProducts.Add(pheremoneComponent * edgeComponent);
            }

            componentProducts = SumComponentProductsCumulatively(componentProducts);

            int cityToMoveTo = PickCityBasedOnComponents(componentProducts, citiesBeingConsideredToTravelTo);

            return cityToMoveTo;
        }

        private List<double> SumComponentProductsCumulatively(List<double> componentProducts)
        {
            List<double> summedProducts = new List<double>();

            for (int index = 0; index <= componentProducts.Count - 2; index++)
            {
                summedProducts.Add(componentProducts.ElementAt(index) + componentProducts.ElementAt(index + 1));
            }

            return summedProducts;
        }

        private int PickCityBasedOnComponents(List<double> componentProducts, List<int> citiesBeingConsideredToTravelTo)
        {
            double boundary = random.NextDouble();
            boundary *= componentProducts.Last();

            for(int cityToMoveTo = 0; cityToMoveTo < componentProducts.Count - 1; cityToMoveTo++)
            {
                if(boundary < componentProducts.ElementAt(cityToMoveTo))
                {
                    return citiesBeingConsideredToTravelTo.ElementAt(cityToMoveTo);
                }
            }

            return citiesBeingConsideredToTravelTo.Last();
        }
    }
}
