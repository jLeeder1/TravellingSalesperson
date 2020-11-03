using System;
using System.Collections.Generic;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public class Ant
    {
        private readonly int startEndCity;

        public Ant(int startEndCity)
        {
            this.startEndCity = startEndCity;
        }

        public int[] ConstructGreedyRoute(Graph graph)
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
            return currentRoute.ToArray();
        }

        private int ChooseNextCityToVisit(PheromoneLookup pheromoneLookup)
        {
            // GOT TO THIS BIT, STEP 5 STILL TRYING TO GET MY HEAD ROUND IT
            return null;
        }
    }
}
