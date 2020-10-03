using System;
using System.Collections.Generic;

namespace TravellingSalespersonProj
{
    public class Node
    {
        public Dictionary<float, float> Edges { get; set; }

        public Node()
        {
            Edges = new Dictionary<float, float>();
        }

        // For testing
        public string PrintAllDestinationsAndWeights()
        {
            string test = "";

            foreach (KeyValuePair<float, float> entry in Edges)
            {
                test += ($"Destination and weight: {entry.Key} {entry.Value}" + System.Environment.NewLine);
            }

            return test;
        }
    }
}
