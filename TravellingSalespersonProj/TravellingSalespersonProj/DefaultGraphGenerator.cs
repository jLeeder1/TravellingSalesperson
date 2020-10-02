using System;
using System.Collections.Generic;

namespace TravellingSalespersonProj
{
    class DefaultGraphGenerator
    {
        private List<Node> nodes;

        public DefaultGraphGenerator()
        {
            nodes = new List<Node>();
            GenerateNodes();
            GenerateEdges();
        }

        public Graph GenerateGraph()
        {
            Graph graph = new Graph();


            return graph;
        }

        public List<Node> GenerateNodes()
        {
            for (int index = 0; index < 5; index++)
            {
                string nodeLetter = ConvertIntToString.Convert(index);
                nodes.Add(new Node(nodeLetter));
            }

            //  just for testing
            foreach (Node node in nodes)
            {
                Console.WriteLine(node.NodeLetter);
            }

            return nodes;
        }

        public List<Edge> GenerateEdges()
        {
            List<Edge> edges = new List<Edge>();

            string[,] defaultEdges = GetEdgesWithWeightValues();

            for(int index = 0; index < defaultEdges.GetLength(0); index++)
            {
                Node firstNode = GetNodeByNodeLetter(defaultEdges[index, 0]);
                Node secondNode = GetNodeByNodeLetter(defaultEdges[index, 1]);
                int  weight = ConvertStringToInt(defaultEdges[index, 2]);

                // Reverses order: for example adds A to B and B to A with same weight at the same time
                edges.Add(new Edge(weight, firstNode, secondNode));
                edges.Add(new Edge(weight, secondNode, firstNode));
            }

            //  just for testing
            foreach (Edge edge in edges)
            {
                Console.WriteLine(edge.ConnectedNodes[0].NodeLetter);
                Console.WriteLine(edge.ConnectedNodes[1].NodeLetter);
                Console.WriteLine(edge.Weight);
                Console.WriteLine();
            }

            return edges;
        }

        private Node GetNodeByNodeLetter(string letter)
        {
            foreach(Node node in nodes)
            {
                if (node.NodeLetter.Equals(letter))
                {
                    return node;
                }
            }

            // not a great way to handle it
            return null;
        }

        private int ConvertStringToInt(string stringToConvert)
        {
            try
            {
                int numVal = Int32.Parse(stringToConvert);
                return numVal;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        private string[,] GetEdgesWithWeightValues()
        {
            return new string[,]
            {
                { "A", "B", "20" },
                { "A", "C", "42" },
                { "A", "D", "35" },
                { "B", "C", "30" },
                { "B", "D", "34" },
                { "C", "D", "12" }
            };
        }
    }
}   