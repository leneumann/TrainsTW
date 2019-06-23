using System.Collections.Generic;
using System.Linq;
using Trains.Domain.RailRoad;

namespace Trains.Domain.Algorithms
{
    public class DistanceOfTheRoute : IStepsSearch
    {
        private List<Node> Nodes;
        public string find(params Node[] steps)
        {
            Nodes = steps.ToList();
            var totalDistance = 0;
            var visitingNode = NextNodeToVisit();

            while (HasNodesToVisit)
            {
                var nextNode = NextNodeToVisit();

                if (notFoundNextNode(visitingNode, nextNode))
                    return ($"PATH NOT FOUND");

                foreach (var adjacent in visitingNode.getAdjacents())
                {
                    if (adjacent.Node == nextNode)
                        totalDistance += adjacent.Wheight;
                }
                visitingNode = nextNode;
            }
            return totalDistance.ToString();
        }

        private Node NextNodeToVisit()
        {
            var node = Nodes.FirstOrDefault();
            Nodes.Remove(node);
            return node;
        }

        private bool HasNodesToVisit => Nodes.Any();

        private static bool notFoundNextNode(Node visitingNode, Node nextNode)
        {
            return !visitingNode.getAdjacents().Any(x => x.Node == nextNode);
        }





    }
}