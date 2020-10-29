using System;
using System.Collections.Generic;
using System.Text;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class ParentSelection
    {
        private List<WheelSegment> rouletteWheel;
        private Random random;

        public ParentSelection()
        {
            rouletteWheel = new List<WheelSegment>();
            random = new Random();
        }

        public Route[] ParentRouletteSelection(List<Route> currentPopulation, int numberOfParentsNeeded = 2)
        {
            float sumOfFitnesses = SumAllParentFitnesses(currentPopulation);

            rouletteWheel = PopulateRouletteWheelWithWeightedFitnesses(sumOfFitnesses, currentPopulation);
            return null;
        }

        private float SumAllParentFitnesses(List<Route> currentPopulation)
        {
            float sumOfFitnesses = 0.0f;

            foreach(Route currentIndividual in currentPopulation)
            {
                sumOfFitnesses += currentIndividual.RouteCost;
            }

            return sumOfFitnesses;
        }

        /**
         * This populate a List<WheelSegment>
         * The float represents the lower boundary of the Routes segment on the wheel
         * The upper boundary will then be the lower boundary on the next element in the list
         */
        private List<WheelSegment> PopulateRouletteWheelWithWeightedFitnesses(float sumOfFitnesses, List<Route> currentPopulation)
        {
            float currentSegmentStartPosition = 0.0f;
            List<WheelSegment> rouletteWheel = new List<WheelSegment>();

            foreach(Route currentIndividual in currentPopulation)
            {
                float individualPercentageOfWheel = currentIndividual.RouteCost / sumOfFitnesses;
                float lowerBound = currentSegmentStartPosition + individualPercentageOfWheel;

                rouletteWheel.Add(new WheelSegment(currentIndividual, lowerBound));

                currentSegmentStartPosition = lowerBound;
            }

            return rouletteWheel;
        }

        /**
         * Uses random number to pick a number of parents from the wheel
         * The random number will fall between the boundaries of two segments
         */
        private Route[] PickRandomParentsFromWheel(int numberOfParents)
        {
            
        }
    }
}
