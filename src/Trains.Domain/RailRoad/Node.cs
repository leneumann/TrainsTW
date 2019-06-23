using System.Collections.Generic;

namespace Trains.Domain.RailRoad
{
    public class Node
    {
        public char Label { get; private set; }
        private LinkedList<Edge> Adjacents { get; set; }

        public Node(char label)
        {
            Label = label;
            Adjacents = new LinkedList<Edge>();
        }
        public static Node createNode(char label) => new Node(label);
        public void connectTo(Node node, int wheight)
        {
            var edge = Edge.createEdge(node, wheight);
            addToAdjacents(edge);
        }
        private void addToAdjacents(Edge edge) => Adjacents.AddLast(edge);

        public LinkedList<Edge> getAdjacents() => Adjacents;
    }
}