using System;
using System.Collections.Generic;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj.EvolutionaryAlgorithms
{
    public class EvolutionaryAlgorithmMenu
    {
        private readonly CustomValueInput customValueInput;
        private readonly EvolutionaryAlgorithmController evolutionaryAlgorithmController;

        public EvolutionaryAlgorithmMenu()
        {
            customValueInput = new CustomValueInput();
            evolutionaryAlgorithmController = new EvolutionaryAlgorithmController();
        }

        public void RunMenu(Graph graph)
        {
            DisplayMenuOptions();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    EvolutionaryAlgorithmConstants.ResetValuesToDefault();
                    break;
                case ConsoleKey.D2:
                    customValueInput.GetCustomVariables();
                    break;
                default:
                    break;
            }


            RunEvolutionaryAlgorithm(graph);
            EvolutionaryAlgorithmConstants.DisplayConstants();
        }

        private void DisplayMenuOptions()
        {
            Console.WriteLine($"Please enter a number from the choices below:{System.Environment.NewLine}");
            Console.WriteLine($"1: Run with default variables");
            Console.WriteLine($"2: Run with custom variables");
            Console.WriteLine(System.Environment.NewLine);
        }

        private void RunEvolutionaryAlgorithm(Graph graph)
        {
            Dictionary<int, Route> bestRoutes = evolutionaryAlgorithmController.RunEvolutionaryAlgorithm(EvolutionaryAlgorithmConstants.STARTING_NODE, graph);
            DataDisplay.PrintDictionaryOfBestRoutes(bestRoutes);
            DataDisplay.PrintBestRouteOverall(bestRoutes);
        }
    }
}
