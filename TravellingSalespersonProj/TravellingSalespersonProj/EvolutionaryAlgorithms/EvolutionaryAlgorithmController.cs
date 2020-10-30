using System;
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
        private readonly Recombination recombination;
        private readonly Random random;


        private List<Route> parentPopulation;
        private List<Route> offspringPopulation;
        

        public Dictionary<int, Route> BestRouteInGeneration { get; set; }

        public EvolutionaryAlgorithmController()
        {
            randomRouteGenerator = new RandomRouteGenerator();
            routeEvaluator = new RouteEvaluator();
            parentSelection = new ParentSelection();
            parentSelection = new ParentSelection();
            recombination = new Recombination();
            random = new Random();

            parentPopulation = new List<Route>();
            offspringPopulation = new List<Route>();
            BestRouteInGeneration = new Dictionary<int, Route>();
            
        }

        public Dictionary<int, Route> RunEvolutionaryAlgorithm(int sizeOfPopulation, int startingNode, int numOfGenerations, Graph graph)
        {
            AddInitialBestRouteForGenerationZero(startingNode, graph);
            this.parentPopulation = InitialisePoplulation(sizeOfPopulation, startingNode, graph);

            for(int generationNumber = 0; generationNumber < numOfGenerations; generationNumber++)
            {
                //parentSelection.ParentRouletteSelection(populationOne);
                //List<Route> parents = parentSelection.ParentTournamentSelection(populationOne, 10);

                // Generate a list of individuals offspring will be generated from
                List<Route> potentialParents = new List<Route>();

                while (potentialParents.Count <= parentPopulation.Count) // THERE IS A PROBLEM HERE
                {
                    potentialParents.AddRange(parentSelection.DefaultTournamentSelection(parentPopulation, 10));
                }

                // Generate an offspring population
                while (offspringPopulation.Count <= parentPopulation.Count)
                {
                    // Pick two random parents from the pool of potential parents
                    Route parentOne = potentialParents.ElementAt(random.Next(0, potentialParents.Count - 1));
                    Route parentTwo = potentialParents.ElementAt(random.Next(0, potentialParents.Count - 1));

                    offspringPopulation.AddRange(recombination.RunRecombination(parentOne, parentTwo));
                }

                CalculateRouteCostsForIndividualsInGeneration(offspringPopulation, graph);
                FindBestRouteInGeneration(generationNumber, offspringPopulation);

                ResetGenerations(parentPopulation, offspringPopulation);
            }

            return BestRouteInGeneration;
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

        private void CalculateRouteCostsForIndividualsInGeneration(List<Route> population, Graph graph)
        {
            foreach(Route individual in population)
            {
                individual.RouteCost = routeEvaluator.CalculateCostOfSingleRoute(individual.RouteIds, graph);
            }
        }

        private void FindBestRouteInGeneration(int generationNumber, List<Route> population)
        {
            population.Sort((x, y) => x.RouteCost.CompareTo(y.RouteCost));

            BestRouteInGeneration[generationNumber] = population.First();
        }

        private void ResetGenerations(List<Route> parentPopulation, List<Route> offspringPopulation)
        {
            parentPopulation.Clear();
            parentPopulation.AddRange(offspringPopulation);
            offspringPopulation.Clear();
        }
    }
}
