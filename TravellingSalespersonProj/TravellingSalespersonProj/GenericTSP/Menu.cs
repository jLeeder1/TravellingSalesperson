using System;
using System.Collections.Generic;
using TravellingSalespersonProj.EvolutionaryAlgorithms;
using TravellingSalespersonProj.LocalSearchTutorial;

namespace TravellingSalespersonProj
{
    public class Menu
    {
        private readonly RandomRouteGenerator randomRouteGenerator;
        private readonly RouteEvaluator routeEvaluator;
        private readonly Graph graph;
        private readonly FileReader fileReader;
        private readonly TimeBasedEvaluator timeBasedEvaluator;
        private readonly EvolutionaryAlgorithmController evolutionaryAlgorithmController;
        private readonly EvolutionaryAlgorithmMenu evolutionaryAlgorithmMenu;

        public Menu()
        {
            this.randomRouteGenerator = new RandomRouteGenerator();
            this.routeEvaluator = new RouteEvaluator();
            this.graph = new Graph();
            this.fileReader = new FileReader();
            this.timeBasedEvaluator = new TimeBasedEvaluator();
            this.evolutionaryAlgorithmController = new EvolutionaryAlgorithmController();
            this.evolutionaryAlgorithmMenu = new EvolutionaryAlgorithmMenu();
        }

        public void RunMenu()
        {
            bool isProgramStillOpen = true;

            while (isProgramStillOpen)
            {
                DisplayMenuOptions();
                graph.GraphOfNodes.Clear();

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        RunWithDefaultGraph();
                        break;
                    case ConsoleKey.D2:
                        RunWithFileReadGraph();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Not yet implemented");
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Please enter the amount of seconds to run for as an integer");
                        int timeToExecuteFor = int.Parse(Console.ReadLine());
                        RunTimeBasedRandomSearch(timeToExecuteFor);
                        break;
                    case ConsoleKey.D5:
                        ReadGraphFromFile();
                        RunLocalSearch();
                        break;
                    case ConsoleKey.D6:
                        ReadGraphFromFile();
                        evolutionaryAlgorithmMenu.RunMenu(graph);
                        break;
                    default:
                        isProgramStillOpen = false;
                        break;
                }
            }
        }

        private void DisplayMenuOptions()
        {
            Console.WriteLine($"Please enter a number from the choices below:{System.Environment.NewLine}");
            Console.WriteLine($"1: Run with default graph");
            Console.WriteLine($"2: Run random route with ulysses16.csv");
            Console.WriteLine($"3: Run all routes with ulysses16.csv");
            Console.WriteLine($"4: Run ulysses16.csv with time based random search");
            Console.WriteLine($"5: Run local search");
            Console.WriteLine($"6: Run evolutionary algorithm");
            Console.WriteLine($"Press enter key to end Program");
        }

        private void RunWithDefaultGraph()
        {
            graph.PopulateGraphWithDefaultValues();
            DataDisplay.PrintGraphOfNodes(graph);
            EvaluateRouteAndPrint();
        }

        private void RunWithFileReadGraph()
        {
            ReadGraphFromFile();
            DataDisplay.PrintGraphOfNodes(graph);
            EvaluateRouteAndPrint();
        }

        private void RunTimeBasedRandomSearch(int timeToExecuteFor)
        {
            ReadGraphFromFile();
            KeyValuePair<int[], double> routeAndTimeTaken = timeBasedEvaluator.CalculateBestRandomRouteInGivenTime(graph, timeToExecuteFor);
            DataDisplay.PrintRouteAndCalculation(routeAndTimeTaken.Key, routeAndTimeTaken.Value);
        }

        private void RunLocalSearch()
        {
            LocalSearch localSearch = new LocalSearch();
            Route bestRoute = localSearch.RunLocalSearch(graph, randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, 0));
            DataDisplay.PrintRouteAndCalculation(bestRoute.RouteIds, bestRoute.RouteCost);
        }

        private void ReadGraphFromFile()
        {
            fileReader.ReadFileOfTypeCSV(graph);
        }

        private void EvaluateRouteAndPrint()
        {
            int[] route = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, 0);
            double costOfRoute = routeEvaluator.CalculateCostOfSingleRoute(route, graph);
            DataDisplay.PrintRouteAndCalculation(route, costOfRoute);
        }
    }
}
