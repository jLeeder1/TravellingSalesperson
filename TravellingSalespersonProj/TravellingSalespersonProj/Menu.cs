using System;
using System.Collections.Generic;
using System.Text;
using TravellingSalespersonProj.LocalSearch;

namespace TravellingSalespersonProj
{
    public class Menu
    {
        private readonly RandomRouteGenerator randomRouteGenerator;
        private readonly RouteEvaluator routeEvaluator;
        private readonly Graph graph;
        private readonly FileReader fileReader;
        private readonly TimeBasedEvaluator timeBasedEvaluator;

        public Menu()
        {
            this.randomRouteGenerator = new RandomRouteGenerator();
            this.routeEvaluator = new RouteEvaluator();
            this.graph = new Graph();
            this.fileReader = new FileReader();
            this.timeBasedEvaluator = new TimeBasedEvaluator();
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
            KeyValuePair<int[], float> routeAndTimeTaken = timeBasedEvaluator.CalculateBestRandomRouteInGivenTime(graph, timeToExecuteFor);
            DataDisplay.PrintRouteAndCalculation(routeAndTimeTaken.Key, routeAndTimeTaken.Value);
        }

        private void ReadGraphFromFile()
        {
            fileReader.ReadFileOfTypeCSV(graph);
        }

        private void EvaluateRouteAndPrint()
        {
            int[] route = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, 0);
            float costOfRoute = routeEvaluator.CalculateCostOfSingleRoute(route, graph);
            DataDisplay.PrintRouteAndCalculation(route, costOfRoute);
        }
    }
}
