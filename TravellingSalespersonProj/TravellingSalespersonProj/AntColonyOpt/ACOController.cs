using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.AntColonyOpt
{
    public class ACOController
    {
        public Dictionary<int, Route> BestRouteInGeneration { get; set; }

        private readonly PheromoneLookup pheromoneLookup;
        private readonly RouteEvaluator routeEvaluator;

        private List<Ant> antPopulation;

        public ACOController()
        {
            BestRouteInGeneration = new Dictionary<int, Route>();

            pheromoneLookup = new PheromoneLookup();
            routeEvaluator = new RouteEvaluator();
            antPopulation = new List<Ant>();
        }

        public Dictionary<int, Route> RunACO(Graph graph)
        {
            pheromoneLookup.InitialisePheremoneOnAllEdges(graph.GraphOfNodes.Count);
            antPopulation = InitialiseAntPopulation();

            for(int generation = 0; generation < ACOConstants.DEFAULT_ANT_GENERATIONS; generation++)
            {
                foreach (Ant ant in antPopulation)
                {
                    Route route = ant.WalkRoute(pheromoneLookup, routeEvaluator, graph);
                    route.RouteCost = routeEvaluator.CalculateCostOfSingleRoute(route.RouteIds, graph);
                }

                // Seperate loop for pheremones so ants do not converge on a single route immediately
                foreach (Ant ant in antPopulation)
                {
                    pheromoneLookup.UpdatePheromoneForSingleRoute(ant.AntRoute.RouteIds);
                    ant.ClearRoutes();
                }

                pheromoneLookup.DecayAllPheromones();

                List<Route> antRoutes = new List<Route>();
                antPopulation.ForEach(ant => antRoutes.Add(ant.AntRoute));

                FindBestRouteInGeneration(generation, antRoutes);
            }

            return BestRouteInGeneration;
        }

        private List<Ant> InitialiseAntPopulation()
        {
            List<Ant> tempAnts = new List<Ant>();

            for(int index = 0; index < ACOConstants.DEFAULT_ANT_POPULATION; index++)
            {
                tempAnts.Add(new Ant());
            }

            return tempAnts;
        }

        private void FindBestRouteInGeneration(int generationNumber, List<Route> population)
        {
            population.Sort((x, y) => x.RouteCost.CompareTo(y.RouteCost));

            BestRouteInGeneration[generationNumber] = population.First();
        }
    }
}
