using System;
using System.Collections.Generic;

namespace TravellingSalespersonProj
{
    public class Node
    {
        public Dictionary<string, int> Edges { get; set; }

        public Node()
        {
            Edges = new Dictionary<string, int>();
        }

        // For testing
        public string PrintAllDestinationsAndWeights()
        {
            string test = "";

            foreach (KeyValuePair<string, int> entry in Edges)
            {
                test += ($"Destination and weight: {entry.Key} {entry.Value}" + System.Environment.NewLine);
            }

            return test;
        }
    }
}
