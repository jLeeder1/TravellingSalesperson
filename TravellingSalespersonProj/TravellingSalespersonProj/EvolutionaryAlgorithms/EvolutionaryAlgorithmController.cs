using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class EvolutionaryAlgorithmController
    {
        private readonly RandomRouteGenerator randomRouteGenerator;
        private readonly RouteEvaluator routeEvaluator;
        private readonly ParentSelection parentSelection;


        private List<Route> populationOne;
        private List<Route> populationTwo;
        private bool isUsingPopulationOne;
        

        public Dictionary<int, Route> BestRouteInGeneration { get; set; }

        public EvolutionaryAlgorithmController()
        {
            randomRouteGenerator = new RandomRouteGenerator();
            routeEvaluator = new RouteEvaluator();
            parentSelection = new ParentSelection();
            populationOne = new List<Route>();
            populationTwo = new List<Route>();
            isUsingPopulationOne = true;
            BestRouteInGeneration = new Dictionary<int, Route>();
            
        }

        public Route RunEvolutionaryAlgorithm(int sizeOfPopulation, int startingNode, Graph graph)
        {
            AddInitialBestRouteForGenerationZero(startingNode, graph);
            this.populationOne = InitialisePoplulation(sizeOfPopulation, startingNode, graph);

            bool terminationCondition = true;

            while (terminationCondition)
            {
                //parentSelection.ParentRouletteSelection(populationOne);
                parentSelection.ParentTournamentSelection(populationOne, 10);
            }

            return null;
        }

        private List<Route> InitialisePoplulation(int sizeOfPopulation, int startingNode, Graph graph)
        {
            List<Route> tempPopulation = new List<Route>();

            for(int index = 0; index < sizeOfPopulation; index++)
            {
                int[] routeIds = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, startingNode);
                float routeCost = routeEvaluator.CalculateCostOfSingleRoute(routeIds, graph);

                Route currentRoute = new Route(routeIds, routeCost);

                Route currentBestRoute = BestRouteInGeneration.ElementAt(0).Value;
                if (currentRoute.RouteCost < currentBestRoute.RouteCost)
                {
                    BestRouteInGeneration.Remove(0);
                    BestRouteInGeneration.Add(0, currentRoute);
                }

                tempPopulation.Add(currentRoute);
            }

            return tempPopulation;
        }

        private void AddInitialBestRouteForGenerationZero(int startingNode, Graph graph)
        {
            // Adds a random initial best route for the generation
            int[] tempRoute = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, startingNode);
            float tempRouteCost = routeEvaluator.CalculateCostOfSingleRoute(tempRoute, graph);
            BestRouteInGeneration.Add(0, new Route(tempRoute, tempRouteCost));
        }
    }
}
