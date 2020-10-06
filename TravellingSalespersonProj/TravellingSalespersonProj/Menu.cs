using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalespersonProj
{
    public class Menu
    {
        RandomRouteGenerator randomRouteGenerator;
        RouteEvaluator routeEvaluator;
        Graph graph;

        public Menu()
        {
            this.randomRouteGenerator = new RandomRouteGenerator();
            this.routeEvaluator = new RouteEvaluator();
            graph = new Graph();
        }

        public void RunMenu()
        {
            Console.WriteLine($"Please enter a number from the choices below:{System.Environment.NewLine}");
            Console.WriteLine($"1: Run with default graph");
            Console.WriteLine($"2: Run random route with ulysses16.csv");
            Console.WriteLine($"3: Run all routes with ulysses16.csv");
            Console.WriteLine($"4: End Program");

            MenuBackend();
        }

        private void MenuBackend()
        {
            bool isProgramStillOpen = true;

            while (isProgramStillOpen)
            {
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
    
        private void RunWithDefaultGraph()
        {
            graph.RunDefaultGraphSetUp();
            int[] route = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, 0);
            float costOfRoute = routeEvaluator.CalculateCostOfSingleRoute(route, graph);
            PrintRouteAndCalculation(route, costOfRoute);
            RunMenu();
        }

        private void RunWithFileReadGraph()
        {
            FileReader fileReader = new FileReader();
            fileReader.ReadFileOfTypeCSV(graph);
            int[] route = randomRouteGenerator.GenerateSingleRandomRoute(graph.GraphOfNodes.Count, 0);
            float costOfRoute = routeEvaluator.CalculateCostOfSingleRoute(route, graph);
            PrintRouteAndCalculation(route, costOfRoute);
            RunMenu();
        }

        private void PrintRouteAndCalculation(int[] route, float costOfRoute)
        {
            string routePath = String.Empty;

            foreach(int nodeId in route)
            {
                routePath = $"{routePath} {nodeId.ToString()}";
            }

            Console.WriteLine($"The route taken was {routePath} with a cost of {costOfRoute}");
        }
    }
}
