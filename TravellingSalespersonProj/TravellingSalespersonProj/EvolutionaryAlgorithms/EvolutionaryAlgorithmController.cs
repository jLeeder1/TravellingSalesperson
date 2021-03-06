﻿using System;
using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class EvolutionaryAlgorithmController
    {
        private IRecombinationStrategy recombination;
        private readonly RandomRouteGenerator randomRouteGenerator;
        private readonly RouteEvaluator routeEvaluator;
        private readonly ParentSelection parentSelection;
        private readonly Mutation mutation;
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
            mutation = new Mutation();
            random = new Random();

            parentPopulation = new List<Route>();
            offspringPopulation = new List<Route>();
            BestRouteInGeneration = new Dictionary<int, Route>();
        }

        public Dictionary<int, Route> RunEvolutionaryAlgorithm(Graph graph)
        {
            ChooseRecombinationStrategy();
            AddInitialBestRouteForGenerationZero(graph);
            this.parentPopulation = InitialisePoplulation(graph);

            for(int generationNumber = 0; generationNumber < EvolutionaryAlgorithmConstants.NUMBER_OF_GENERATIONS; generationNumber++)
            {
                // Generate a list of individuals offspring will be generated from
                List<Route> potentialParents = new List<Route>();

                potentialParents.AddRange(parentSelection.DefaultTournamentSelection(parentPopulation));

                // Generate an offspring population
                while (offspringPopulation.Count < parentPopulation.Count)
                {
                    // Pick two random parents from the pool of potential parents
                    Route parentOne = potentialParents.ElementAt(random.Next(0, potentialParents.Count - 1));
                    Route parentTwo = potentialParents.ElementAt(random.Next(0, potentialParents.Count - 1));

                    offspringPopulation.AddRange(recombination.RunRecombination(parentOne, parentTwo));
                }

                
                foreach(Route offspring in offspringPopulation)
                {
                    mutation.SwapMutateIndividual(offspring);
                }

                CalculateRouteCostsForIndividualsInGeneration(offspringPopulation, graph);
                FindBestRouteInGeneration(generationNumber, offspringPopulation);

                ResetGenerations(parentPopulation, offspringPopulation);
            }

            return BestRouteInGeneration;
        }

        private List<Route> InitialisePoplulation(Graph graph)
        {
            List<Route> tempPopulation = new List<Route>();

            for(int index = 0; index < EvolutionaryAlgorithmConstants.POPULATION_SIZE; index++)
            {
                int[] routeIds = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count);
                double routeCost = routeEvaluator.CalculateCostOfSingleRoute(routeIds, graph);

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

        private void AddInitialBestRouteForGenerationZero(Graph graph)
        {
            // Adds a random initial best route for the generation
            int[] tempRoute = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count);
            double tempRouteCost = routeEvaluator.CalculateCostOfSingleRoute(tempRoute, graph);

            if(BestRouteInGeneration.ContainsKey(0))
            {
                BestRouteInGeneration.Remove(0);
            }

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

        private void ChooseRecombinationStrategy()
        {
            if(EvolutionaryAlgorithmConstants.IS_USING_RANDOM_START_END_CITY == false)
            {
                recombination = new Recombination();
            }
            else
            {
                recombination = new RecombinationVariableStartEnd();
            }
        }
    }
}
