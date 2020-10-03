using System;
using System.Collections.Generic;
using System.Linq;

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

            foreach (KeyValuePair<string, Node> entry in graph.NodesInCity)
            {
                Console.WriteLine($"Starting Node: {entry.Key}{System.Environment.NewLine}{entry.Value.PrintAllDestinationsAndWeights()}");
            }

            routeGenerator.GenerateRoutes(4, "A");
            */
            HashSet<string[]> test = new HashSet<string[]>();

            string[] route = new string[] { "A", "B", "20" };
            string[] routeTwo = new string[] { "A", "B", "20" };

            test.Add(route);
            test.Add(routeTwo);

            foreach(string[] current in test)
            {
                for(int i = 0; i < current.Length; i++)
                {
                    Console.WriteLine(current[i]);
                }
            }
            Console.WriteLine(test.Count());
        }

    }
}
