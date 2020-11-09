using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class RecombinationVariableStartEnd
    {
        private readonly Random random;

        public RecombinationVariableStartEnd()
        {
            random = new Random();
        }

        public Route RunRecombination(Route parentOne, Route parentTwo)
        {
            // Initialise offspring route
            int[] offspringRoute = new int[parentOne.RouteIds.Length - 2];

            // Get range of elements to copy from parent one
            int[] spliceStartEndIndexes = GetParentOneSpliceIndexes(parentOne);

            // Choose start and end city from parent start and end cities
            int offspringStartEndCity = ChooseStartEndCityFromParents(parentOne, parentTwo);

            // Add part of parent one to offspring
            offspringRoute = AddFirstPartOfParentOne(offspringRoute, spliceStartEndIndexes, parentOne, offspringStartEndCity);

            // Add part of parent two to offspring
            offspringRoute = AddSecondParentOfParentTwo(offspringRoute, spliceStartEndIndexes, parentTwo, offspringStartEndCity);

            return null;
        }

        private int[] GetParentOneSpliceIndexes(Route parentOne)
        {
            int spiceStartIndex = random.Next(0, parentOne.RouteIds.Length - 2);
            int spiceEndIndex = random.Next(spiceStartIndex + 1, parentOne.RouteIds.Length - 2);

            return new int[] { spiceStartIndex, spiceEndIndex };
        }

        private int ChooseStartEndCityFromParents(Route parentOne, Route parentTwo)
        {
            if(random.Next(0,2) == 1)
            {
                return parentOne.RouteIds[0];
            }

            return parentTwo.RouteIds[0];
        }

        private int[] AddFirstPartOfParentOne(int[] offspringRoute, int[] spliceStartEndIndexes, Route parentOne, int offspringStartEndCity)
        {
            int indexToAddInOffspring = spliceStartEndIndexes[0];
            int indexOfParentSplice = spliceStartEndIndexes[0];
            int numberOfElementsLeftToCopy = spliceStartEndIndexes[1] - spliceStartEndIndexes[0];

            while(numberOfElementsLeftToCopy > 0)
            {
                if (parentOne.RouteIds[indexOfParentSplice] == offspringStartEndCity)
                {
                    continue;
                }

                if (!offspringRoute.Contains(parentOne.RouteIds[indexOfParentSplice]))
                {
                    offspringRoute[indexToAddInOffspring] = parentOne.RouteIds[indexOfParentSplice];
                    indexToAddInOffspring++;
                    numberOfElementsLeftToCopy--;
                }

                indexOfParentSplice++;
            }

            return offspringRoute;
        }

        private int[] AddSecondParentOfParentTwo(int[] offspringRoute, int[] spliceStartEndIndexes, Route parentTwo, int offspringStartEndCity)
        {
            int indexToAddInOffspring = spliceStartEndIndexes[1];
            int indexOfParentSplice = spliceStartEndIndexes[1];
            int numberOfElementsLeftToCopy = offspringRoute.Length - spliceStartEndIndexes[1] - spliceStartEndIndexes[0];

            while (numberOfElementsLeftToCopy > 0)
            {
                if (parentTwo.RouteIds[indexOfParentSplice] == offspringStartEndCity)
                {
                    continue;
                }

                if (!offspringRoute.Contains(parentTwo.RouteIds[indexOfParentSplice]))
                {
                    offspringRoute[indexToAddInOffspring] = parentTwo.RouteIds[indexOfParentSplice];
                    indexToAddInOffspring++;
                    numberOfElementsLeftToCopy--;
                }

                indexOfParentSplice++;
            }

            return offspringRoute;
        }
    }
}
