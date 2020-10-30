using System;
using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.GenericTSP;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class Recombination
    {
        private Random random;
        private TourFormatter tourFormatter;

        public Recombination()
        {
            random = new Random();
            tourFormatter = new TourFormatter();
        }

        public List<Route> RunRecombination(Route parentOne, Route parentTwo)
        {
            List<Route> offspring = new List<Route>
            {
                OrderOneCrossover(
                tourFormatter.RemoveStartAndEndNodeToRoute(parentOne.RouteIds),
                tourFormatter.RemoveStartAndEndNodeToRoute(parentTwo.RouteIds),
                parentOne.RouteIds.First()),

                OrderOneCrossover(
                tourFormatter.RemoveStartAndEndNodeToRoute(parentTwo.RouteIds),
                tourFormatter.RemoveStartAndEndNodeToRoute(parentOne.RouteIds),
                parentOne.RouteIds.First())
            };

            return offspring;
        }

        /**
         * This will lead to duplicate cities and some being missed
         * Leaving it in to messa round with it later
         */
        public List<Route> RecombineParentsToFormChild(Route parentOne, Route parentTwo)
        {
            List<int> childOneRoute = new List<int>();
            List<int> childTwoRoute = new List<int>();

            int dividingIndex = random.Next(0, parentOne.RouteIds.Length);

            for(int index = 0; index < dividingIndex; index++)
            {
                // First part of parent One copied into Child One
                childOneRoute.Add(parentOne.RouteIds[index]);

                // First part of parent two copied into Child two
                childTwoRoute.Add(parentTwo.RouteIds[index]);
            }

            for (int index = dividingIndex; index <= parentOne.RouteIds.Length - 1; index++)
            {
                // Second part of parent One copied into Child two
                childTwoRoute.Add(parentOne.RouteIds[index]);

                // Second part of parent two copied into Child one
                childOneRoute.Add(parentTwo.RouteIds[index]);
            }

            List<Route> children = new List<Route>()
            {
                new Route(childOneRoute.ToArray(), double.MaxValue),
                new Route(childTwoRoute.ToArray(), double.MaxValue)
            };

            return children;
        }

        private Route OrderOneCrossover(int[] parentOneRoute, int[] parentTwoRoute, int startEndCity)
        {
            int[] offspringOneRoute = new int[parentOneRoute.Length];

            // Cut a random range of elements from the first parent
            int startingIndex = random.Next(0, parentOneRoute.Length - 1);
            int endingIndex = random.Next(startingIndex, parentOneRoute.Length - 1);

            // Copy the elements between random range into child one
            Array.Copy(parentOneRoute, startingIndex, offspringOneRoute, startingIndex, endingIndex - startingIndex);

            // Two iterators to track what element to pull from the parent and where to insert that element in the child
            int iteratorIndex = endingIndex;
            int currentPositionInChildRoute = endingIndex;
            int numElementsToCopy = parentOneRoute.Length - (endingIndex - startingIndex);

            while (numElementsToCopy > 0)
            {
                if(iteratorIndex > parentOneRoute.Length - 1)
                {
                    iteratorIndex = 0;
                    continue;
                }

                if (!offspringOneRoute.Contains(parentOneRoute[iteratorIndex]))
                {
                    offspringOneRoute[currentPositionInChildRoute] = parentTwoRoute[iteratorIndex];
                    numElementsToCopy--;
                    currentPositionInChildRoute++;
                }

                if(currentPositionInChildRoute > offspringOneRoute.Length - 1)
                {
                    currentPositionInChildRoute = 0;
                }

                iteratorIndex++;
            }

            offspringOneRoute = tourFormatter.AddStartAndEndNodeToRoute(startEndCity, offspringOneRoute);

            return new Route(offspringOneRoute, double.MaxValue);
        }
    }
}
