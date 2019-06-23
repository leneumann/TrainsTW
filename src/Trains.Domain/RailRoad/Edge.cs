namespace Trains.Domain.RailRoad
{
    public class Edge
    {
        public Node Node { get; }
        public int Wheight { get; set; }
        private Edge(Node node, int wheight)
        {
            Node = node;
            Wheight = wheight;
        }
        public static Edge createEdge(Node node, int wheight) => new Edge(node, wheight);
    }
}