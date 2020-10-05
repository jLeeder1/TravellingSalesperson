using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TravellingSalespersonProj.SecondAttempt;

namespace TravellingSalespersonProj
{
    public class Program
    {
        private Graph graph;

        private HashSet<string[]> routes;

        static void Main(string[] args)
        {
            // Always true for now as always using default graph
            /*
            GraphGenerator graphGenerator = new GraphGenerator(true);
            Graph graph = graphGenerator.GenerateGraph();
            RouteGenerator routeGenerator = new RouteGenerator();

            foreach (KeyValuePair<float, Node> entry in graph.NodesInCity)
            {
                Console.WriteLine($"Starting Node: {entry.Key}{System.Environment.NewLine}{entry.Value.PrintAllDestinationsAndWeights()}");
            }

            routeGenerator.GenerateRoutes(4, 0);
            */

            /* Randomly generate routes by randomising array WORKS
            Random rnd = new Random();
            int[] MyRandomArray = new int[] { 1, 2, 3 };

            while (true)
            {
                Test(MyRandomArray);
                MyRandomArray = MyRandomArray.OrderBy(x => rnd.Next()).ToArray();
                Thread.Sleep(2000);
            }

            */

            SecondAttempt.Graph graph = new SecondAttempt.Graph();
            graph.PopulateGraphWithDefaultValues();
            graph.PrintGraphOfNodes();

            Menu menu = new Menu();
            menu.RunMenu();
        }

        private static void Test(int[] array)
        {
            foreach (int number in array)
            {
                Console.WriteLine(number);
                Console.WriteLine();
            }
        }

    }
}
