using System;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class Mutation
    {
        private readonly Random random = new Random();
        private readonly double CHANCE_OF_MUTATION = 0.25;

        public void SwapMutateIndividual(Route individual, int numberOfSwaps = 1)
        {
            // Random chance to mutate
            if(random.Next(1) > CHANCE_OF_MUTATION)
            {
                return;
            }

            int[] updatedRoute = individual.RouteIds;

            for(int index = 1; index <= numberOfSwaps; index++)
            {
                int firstIndex = random.Next(1, updatedRoute.Length - 2);
                int secondIndex = random.Next(1, updatedRoute.Length - 2);

                int tempNode = updatedRoute[firstIndex];

                updatedRoute[firstIndex] = updatedRoute[secondIndex];
                updatedRoute[secondIndex] = tempNode;
            }

            individual.RouteIds = updatedRoute;
        }
    }
}
