namespace TravellingSalespersonProj
{
    public class Edge
    {
        public float Weight { get; set; }

        public Node[] ConnectedNodes { get; set; }

        public Edge(float weight, Node nodeOne, Node nodeTwo)
        {
            this.Weight = weight;

            ConnectedNodes = new Node[2]
            {
                nodeOne,
                nodeTwo
            };
        }
    }
}
