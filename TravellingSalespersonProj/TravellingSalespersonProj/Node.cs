using System.Collections.Generic;

namespace TravellingSalespersonProj
{
    class Node
    {
        public string NodeLetter { get; set; }
        public List<Edge> Edges { get; set; }

        public Node(string nodeLetter)
        {
            this.NodeLetter = nodeLetter;
        }
    }
}
