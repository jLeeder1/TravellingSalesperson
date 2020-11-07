using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class ParentSelection
    {
        private List<WheelSegment> rouletteWheel;
        private readonly Random random;

        public ParentSelection()
        {
            rouletteWheel = new List<WheelSegment>();
            random = new Random();
        }

        public List<Route> ParentTournamentSelection(List<Route> currentPopulation, int tournamentSize, int numberOfParentsNeeded = 2)
        {
            List<Route> populationInTournament = PopulateTournament(currentPopulation, tournamentSize);
            List<Route> selectedParents = new List<Route>();

            // Sort tournament
            populationInTournament.Sort((x, y) => x.RouteCost.CompareTo(y.RouteCost));

            int halfWayTournamentIndex = GetMiddleTournamentIndex(populationInTournament.Count);

            // picks a nuber of parents in the lower half of scores
            for (int index = 0; index < numberOfParentsNeeded; index++)
            {
                selectedParents.Add(populationInTournament.ElementAt(random.Next(0, halfWayTournamentIndex)));
            }

            return selectedParents;
        }

        public List<Route> DefaultTournamentSelection(List<Route> currentPopulation)
        {
            List<Route> parentPopulation = new List<Route>();
            List<Route> parentSample = new List<Route>();

            while(parentPopulation.Count <= currentPopulation.Count - 1)
            {
                // Generates sample for this tournament
                for(int index = 0; index <= EvolutionaryAlgorithmConstants.TOURNAMENT_SIZE; index++)
                {
                    parentSample.Add(currentPopulation.ElementAt(random.Next(0, currentPopulation.Count - 1)));
                }

                // Sorts the routes by their cost
                parentSample.Sort((x, y) => x.RouteCost.CompareTo(y.RouteCost));

                // Get best individual (lowest route score) and add them to the parentPopulation
                Route bestIndividualinTournament = parentSample.First();
                parentPopulation.Add(bestIndividualinTournament);

                parentSample.Clear();
            }

            return parentPopulation;
        }

        public Route[] ParentRouletteSelection(List<Route> currentPopulation, int numberOfParentsNeeded = 2)
        {
            double sumOfFitnesses = SumAllParentFitnesses(currentPopulation);

            rouletteWheel = PopulateRouletteWheelWithWeightedFitnesses(sumOfFitnesses, currentPopulation);

            // REMEMEBR THESE PERCENTAGES ARE CURRENTLY GIVING THE BEST PROPORTION TO THE WORST ROUTES AS THEIR SCORES ARE HIGHER. NEED TO REVERSE THIS
            return null;
        }

        private double SumAllParentFitnesses(List<Route> currentPopulation)
        {
            double sumOfFitnesses = 0.0f;

            foreach (Route currentIndividual in currentPopulation)
            {
                sumOfFitnesses += currentIndividual.RouteCost;
            }

            return sumOfFitnesses;
        }

        /**
         * This populate a List<WheelSegment>
         * The float represents the upper boundary of the Routes segment on the wheel
         * The boundary fro that route is then between the boundary for the elkement previously and theirs
         */
        private List<WheelSegment> PopulateRouletteWheelWithWeightedFitnesses(double sumOfFitnesses, List<Route> currentPopulation)
        {
            double currentSegmentStartPosition = 0.0f;
            List<WheelSegment> rouletteWheel = new List<WheelSegment>();

            foreach (Route currentIndividual in currentPopulation)
            {
                double individualPercentageOfWheel = (currentIndividual.RouteCost / sumOfFitnesses) * 100;
                double upeprBound = currentSegmentStartPosition + individualPercentageOfWheel;

                rouletteWheel.Add(new WheelSegment(currentIndividual, upeprBound));

                currentSegmentStartPosition = upeprBound;
            }

            return rouletteWheel;
        }

        /**
         * Uses random number to pick a number of parents from the wheel
         * The random number will fall between the boundaries of two segments
         */
        private Route[] PickRandomParentsFromWheel(int numberOfParents)
        {
            return null;
        }

        private int GetMiddleTournamentIndex(int populationInTournament)
        {
            // population size is even
            if (populationInTournament % 2 == 0)
            {
                return populationInTournament / 2;
            }

            // population size is odd
            return (populationInTournament / 2) + 1;
        }

        private List<Route> PopulateTournament(List<Route> currentPopulation, int tournamentSize)
        {
            List<Route> populationInTournament = new List<Route>();

            for (int index = 0; index < tournamentSize; index++)
            {
                populationInTournament.Add(currentPopulation.ElementAt(random.Next(0, currentPopulation.Count)));
            }

            return populationInTournament;
        }
    }
}   
