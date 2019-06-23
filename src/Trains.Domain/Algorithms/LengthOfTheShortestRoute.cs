using System.Collections.Generic;
using System.Linq;
using Trains.Domain.RailRoad;

namespace Trains.Domain.Algorithms
{
    public class LengthOfTheShortestRoute:IShortestPathSearch
    {
        private class NodeControl
        {
            public Node Predecessor { get; set; }
            public Node This { get; set; }
            public int Wheight { get; set; }
            public bool IsVisited { get; set; }
        }
        private List<NodeControl> VisitorControl = new List<NodeControl>();

        public int find(Graph graph, Node start, Node Destination)
        {
            addNodesToControl(graph, start);

            while (hasNodesToVisit())
            {
                var visitingNode = getNextNodeToVisit();
                markAsVisited(visitingNode);
                foreach (var edge in visitingNode.This.getAdjacents())
                {
                    relaxEdge(visitingNode, edge);
                }
            }
            return getDistanceTo(Destination);
        }

        private void addNodesToControl(Graph graph, Node start)
        {
            foreach (var node in graph.getListOfNodes())
            {
                var wheight = node == start ? int.MaxValue / 2 : int.MaxValue;
                var item = new NodeControl { Predecessor = null, This = node, Wheight = wheight, IsVisited = false };
                VisitorControl.Add(item);
            }

        }

        private bool hasNodesToVisit() => VisitorControl.Any(x => !x.IsVisited);

        private NodeControl getNextNodeToVisit() => VisitorControl.Where(x => !x.IsVisited).OrderBy(y => y.Wheight).FirstOrDefault();

        private void markAsVisited(NodeControl nodeControl)
        {
            var node = VisitorControl.Find(x => x == nodeControl);
            node.IsVisited = true;
        }

        private void relaxEdge(NodeControl visitingNode, Edge adjacent)
        {
            var adjacentControl = getFromVisitorControl(adjacent.Node);
            var probableWheight = adjacent.Wheight;

            if (adjacentControl.Wheight > probableWheight)
            {
                adjacentControl.Predecessor = visitingNode.This;
                adjacentControl.Wheight = adjacent.Wheight;
            }
        }

        private NodeControl getFromVisitorControl(Node node) => VisitorControl.Find(x => x.This == node);

        private int getDistanceTo(Node Destination)
        {
            var nodeControl = getFromVisitorControl(Destination);
            var distance = 0;
            while (true)
            {
                if (nodeControl.This == Destination && distance > 0)
                    break;
                distance += nodeControl.Wheight;
                nodeControl = getFromVisitorControl(nodeControl.Predecessor);
            }
            return distance;
        }
    }

}
