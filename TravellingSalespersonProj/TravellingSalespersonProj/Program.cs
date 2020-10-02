using System;
using System.Collections.Generic;

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

            foreach (KeyValuePair<string, Node> entry in graph.NodesInCity)
            {
                Console.WriteLine($"Starting Node: {entry.Key}{System.Environment.NewLine}{entry.Value.PrintAllDestinationsAndWeights()}");
            }
        }

    }
}
