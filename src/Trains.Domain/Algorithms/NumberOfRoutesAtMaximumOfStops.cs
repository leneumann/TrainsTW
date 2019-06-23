using System;
using System.Collections.Generic;
using Trains.Domain.RailRoad;

namespace Trains.Domain.Algorithms
{
    public class NumberOfRoutesAtMaximumOfStops:IBreadthFirstSearch
    {
        private LinkedList<ValueTuple<int, Node>> queue = new LinkedList<(int, Node)>();
        private int numberOfRoutesFound = 0;
        public int find(Node start, Node destination, int valueLimit)
        {
            addToQueue(0, start);

            while (queue.Count > 0)
            {
                var sourceNode = getNextFromQueue();
                foreach (var adjacent in sourceNode.Item2.getAdjacents())
                {
                    var level = sourceNode.Item1 + 1;
                   
                    if (adjacent.Node == destination)
                    numberOfRoutesFound++;

                    if (level >= valueLimit)
                        break;

                    addToQueue(level, adjacent.Node);
                }
            }
            return numberOfRoutesFound;
        }

        private void addToQueue(int value, Node node)
        {
            var item = new ValueTuple<int, Node>(value, node);
            queue.AddLast(item);
        }

        private ValueTuple<int, Node> getNextFromQueue()
        {
            var next = queue.First;
            queue.Remove(next);
            return next.Value;
        }
    }
}