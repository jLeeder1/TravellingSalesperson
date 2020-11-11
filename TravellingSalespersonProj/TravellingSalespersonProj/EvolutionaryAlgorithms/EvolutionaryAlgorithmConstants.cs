using System;
using System.Data;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public static class EvolutionaryAlgorithmConstants
    {
        public static int NUMBER_OF_GENERATIONS { get; set; }

        public static int TOURNAMENT_SIZE { get; set; }

        public static int POPULATION_SIZE { get; set; }

        public static double RECOMBINATION_PROBABILITY { get; set; }

        public static double MUTATION_PROBABILITY { get; set; }

        public static bool IS_USING_ELITISM { get; set; } = false;

        public static bool IS_USING_TOURNAMENT { get; set; } = true;

        public static bool IS_USING_RANDOM_START_END_CITY { get; set; } = true;

        public static int STARTING_NODE { get; set; } = 1;

        public static void ResetValuesToDefault()
        {
            NUMBER_OF_GENERATIONS = 100;
            TOURNAMENT_SIZE = 15;
            POPULATION_SIZE = 100;
            RECOMBINATION_PROBABILITY = 0.75;
            MUTATION_PROBABILITY = 0.25;
            IS_USING_RANDOM_START_END_CITY = true;
        }

        public static void DisplayConstants()
        {
            Console.WriteLine($"Number of generations: {EvolutionaryAlgorithmConstants.NUMBER_OF_GENERATIONS}");
            Console.WriteLine($"Tournament size: {EvolutionaryAlgorithmConstants.TOURNAMENT_SIZE}");
            Console.WriteLine($"Population size: {EvolutionaryAlgorithmConstants.POPULATION_SIZE}");
            Console.WriteLine($"Mutation probability: {EvolutionaryAlgorithmConstants.MUTATION_PROBABILITY}");
            Console.WriteLine($"Recombination probability: {EvolutionaryAlgorithmConstants.RECOMBINATION_PROBABILITY}");
            Console.WriteLine($"Is using random start end city: {EvolutionaryAlgorithmConstants.IS_USING_RANDOM_START_END_CITY}");
            Console.WriteLine(System.Environment.NewLine);
        }
    }
}
