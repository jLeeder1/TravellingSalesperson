using System;
using System.Collections.Generic;
using System.Linq;
using TravellingSalespersonProj.GenericTSP;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class Recombination
    {
        private readonly Random random;
        private readonly TourFormatter tourFormatter;

        public Recombination()
        {
            random = new Random();
            tourFormatter = new TourFormatter();
        }

        public List<Route> RunRecombination(Route parentOne, Route parentTwo)
        {
            if (random.Next(1) < EvolutionaryAlgorithmConstants.RECOMBINATION_PROBABILITY)
            {
                return new List<Route>() { parentOne, parentTwo };
            }

            {
                parentOneRoute = tourFormatter.RemoveStartAndEndNodeToRoute(parentOneRoute);
            }
            else
            {
                parentTwoRoute = tourFormatter.RemoveStartAndEndNodeToRoute(parentTwoRoute);
            }


            List<Route> offspring = new List<Route>
            {
                OrderOneCrossover(parentOneRoute, parentTwoRoute, offspringStartEndCity),
                OrderOneCrossover(parentTwoRoute, parentOneRoute, offspringStartEndCity)
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

            offspringOneRoute = AddFirstPartParentOneToOffspring(offspringOneRoute, parentOneRoute, startEndCity, startingIndex, endingIndex);

            offspringOneRoute = AddSecondPartSecondParentToOffspring(offspringOneRoute, parentTwoRoute, startEndCity, startingIndex, endingIndex);

            offspringOneRoute = tourFormatter.AddStartAndEndNodeToRoute(startEndCity, offspringOneRoute);

            return new Route(offspringOneRoute, double.MaxValue);
        }

        private int[] AddFirstPartParentOneToOffspring(int[] offspringOneRoute, int[] parentOneRoute, int startEndCity, int startingIndex, int endingIndex)
        {
            int iteratorIndex = startingIndex;
            int currentPositionInChildRoute = startingIndex;
            int numElementsToCopy = endingIndex - startingIndex;
            
            while(numElementsToCopy > 0)
            {
                if (parentOneRoute[iteratorIndex] != startEndCity)
                {
                    offspringOneRoute[currentPositionInChildRoute] = parentOneRoute[iteratorIndex];
                    numElementsToCopy--;
                    currentPositionInChildRoute++;
                }

                iteratorIndex++;
            }

            return offspringOneRoute;
        }

        private int[] AddSecondPartSecondParentToOffspring(int[] offspringOneRoute, int[] parentTwoRoute, int startEndCity, int startingIndex, int endingIndex)
        {
            int iteratorIndex = endingIndex;
            int currentPositionInChildRoute = endingIndex;
            int numElementsToCopy = parentTwoRoute.Length - (endingIndex - startingIndex);

            while (numElementsToCopy > 0)
            {
                if (iteratorIndex > parentTwoRoute.Length - 1)
                {
                    iteratorIndex = 0;
                    continue;
                }

                if(parentTwoRoute[iteratorIndex] == startEndCity)
                {
                    iteratorIndex++;
                }

                if (!offspringOneRoute.Contains(parentTwoRoute[iteratorIndex]))
                {
                    offspringOneRoute[currentPositionInChildRoute] = parentTwoRoute[iteratorIndex];
                    numElementsToCopy--;
                    currentPositionInChildRoute++;
                }

                if (currentPositionInChildRoute > offspringOneRoute.Length - 1)
                {
                    currentPositionInChildRoute = 0;
                }

                iteratorIndex++;
            }

            return offspringOneRoute;
        }

        private int ChooseRandomStartEndCityFromParents(int[] startEndCities)
        {
            int randomCity = random.Next(0, startEndCities.Length);
            return startEndCities[randomCity];
        }
    }
}
