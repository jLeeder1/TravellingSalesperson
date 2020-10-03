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
            GraphGenerator graphGenerator = new GraphGenerator(true);
            Graph graph = graphGenerator.GenerateGraph();
            RouteGenerator routeGenerator = new RouteGenerator();

            foreach (KeyValuePair<float, Node> entry in graph.NodesInCity)
            {
                Console.WriteLine($"Starting Node: {entry.Key}{System.Environment.NewLine}{entry.Value.PrintAllDestinationsAndWeights()}");
            }

            routeGenerator.GenerateRoutes(4, "A");
        }

    }
}
