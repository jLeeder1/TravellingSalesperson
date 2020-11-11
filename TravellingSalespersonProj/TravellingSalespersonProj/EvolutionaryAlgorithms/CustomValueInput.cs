using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class CustomValueInput
    {
        public void GetCustomVariables()
        {
            Console.WriteLine($"Please enter your choices as they appear below:{System.Environment.NewLine}");
            Console.WriteLine($"1: How many generations? (int)");
            EvolutionaryAlgorithmConstants.NUMBER_OF_GENERATIONS = GetIntValue();

            Console.WriteLine($"2: Tournament size (int)");
            EvolutionaryAlgorithmConstants.TOURNAMENT_SIZE = GetIntValue();

            Console.WriteLine($"3: Population size (int)");
            EvolutionaryAlgorithmConstants.TOURNAMENT_SIZE = GetIntValue();

            Console.WriteLine($"4: Mutation probability (double between 0 and 1)");
            EvolutionaryAlgorithmConstants.MUTATION_PROBABILITY = GetDoubleValue();

            Console.WriteLine($"4: Recombination probability (double between 0 and 1)");
            EvolutionaryAlgorithmConstants.RECOMBINATION_PROBABILITY = GetDoubleValue();

            Console.WriteLine($"5: Use a randomly differnt start end city for all individuals? (0 for no and 1 for yes)");
            EvolutionaryAlgorithmConstants.IS_USING_RANDOM_START_END_CITY = GetBoolValue();
        }

        private int GetIntValue()
        {
            while (true)
            {
                int value;
                var keyValue = Console.ReadLine();
                if (int.TryParse(keyValue.ToString(), out value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid integer");
                }
            }
        }

        private double GetDoubleValue()
        {
            while (true)
            {
                double value;
                var keyValue = Console.ReadLine();
                if (double.TryParse(keyValue.ToString(), out value) && value > 0 && value <= 1)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid double");
                }
            }
        }

        private bool GetBoolValue()
        {
            int myValue = GetIntValue();

            if(myValue == 1)
            {
                return true;
            }

            return false;
        }
    }
}
