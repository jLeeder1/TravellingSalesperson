using System.Data;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public static class EvolutionaryAlgorithmConstants
    {
        public static int NUMBER_OF_GENERATIONS { get; set; } = 100;

        public static int TOURNAMENT_SIZE { get; set; } = 10;

        public static int POPULATION_SIZE { get; set; } = 100;

        public static double RECOMBINATION_PROBABILITY { get; set; } = 0.75;

        public static double MUTATION_PROBABILITY { get; set; } = 0.25;

        public static bool IS_USING_ELITISM { get; set; } = false;

        public static bool IS_USING_TOURNAMENT { get; set; } = true;

        public static int STARTING_NODE { get; set; } = 0;
    }
}
