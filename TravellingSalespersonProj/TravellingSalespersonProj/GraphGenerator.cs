using System;
using System.Collections.Generic;

namespace TravellingSalespersonProj
{
    public class GraphGenerator
    {

        public GraphGenerator(bool isUsingDefaultGraph)
        {
        }

        public Graph GenerateGraph()
        {
            Graph graph = new Graph();

            graph.NodesInCity = GenerateAllNodes();

            foreach (KeyValuePair<float, Node> entry in graph.NodesInCity)
            {
                GenerateEdgesForCurrentNode(entry.Key, entry.Value);
            }

            return graph;
        }

        public Dictionary<float, Node> GenerateAllNodes(int numberOfNodes = 4)
        {
            Dictionary<float, Node> nodes = new Dictionary<float, Node>();

            for (int index = 0; index < numberOfNodes; index++)
            {
                nodes.Add(index, new Node());
            }
            return nodes;
        }

        public Dictionary<float, float> GenerateEdgesForCurrentNode(float startingNodeId, Node currentNode)
        {
            float[,] defaultEdges = GetEdgesWithWeightValues();

            Dictionary<float, float> edges = new Dictionary<float, float>();

            for (int index = 0; index < defaultEdges.GetLength(0); index++)
            {
                if(defaultEdges[index, 0] == startingNodeId)
                {
                    currentNode.Edges.Add(defaultEdges[index, 1], defaultEdges[index, 2]);
                }
            }

            return edges;
        }

        // Follows format: Starting node (0 = A, 1 = B etc), destination node, weight
        private float[,] GetEdgesWithWeightValues()
        {
            return new float[,]
            {
                { 0, 1, 20 },
                { 0, 2, 42 },
                { 0, 3, 35 },
                { 1, 0, 20 },
                { 1, 2, 30 },
                { 1, 3, 34 },
                { 2, 0, 42 },
                { 2, 1, 30 },
                { 2, 3, 12 },
                { 3, 0, 35 },
                { 3, 1, 34 },
                { 3, 2, 12 }
            };
        }
    }
}