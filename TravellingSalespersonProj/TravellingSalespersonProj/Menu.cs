using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj
{
    public class Menu
    {
        readonly RandomRouteGenerator randomRouteGenerator;
        readonly RouteEvaluator routeEvaluator;
        readonly Graph graph;
        readonly FileReader fileReader;

        public Menu()
        {
            this.randomRouteGenerator = new RandomRouteGenerator();
            this.routeEvaluator = new RouteEvaluator();
            this.graph = new Graph();
            this.fileReader = new FileReader();
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
                        isProgramStillOpen = false;
                        break;
                    default:
                        RunWithDefaultGraph();
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
            Console.WriteLine($"4: End Program");
        }

        private void RunWithDefaultGraph()
        {
            graph.PopulateGraphWithDefaultValues();
            DataDisplay.PrintGraphOfNodes(graph);
            EvaluateRouteAndPrint();
        }

        private void RunWithFileReadGraph()
        {
            fileReader.ReadFileOfTypeCSV(graph);
            DataDisplay.PrintGraphOfNodes(graph);
            EvaluateRouteAndPrint();
        }

        private void EvaluateRouteAndPrint()
        {
            int[] route = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, 0);
            float costOfRoute = routeEvaluator.CalculateCostOfSingleRoute(route, graph);
            DataDisplay.PrintRouteAndCalculation(route, costOfRoute);
        }
    }
}
