using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;

namespace Trains.Application
{
    public interface INumberOfRoutesService
    {
        int get(IBreadthFirstSearch searchMechanism, string start, string destination, int valueLimit);
    }
    public class NumberOfRoutesService : INumberOfRoutesService
    {
        public Graph RailRoad { get; }
        public NumberOfRoutesService(Graph railRoad)
        {
            RailRoad = railRoad;
        }

        public int get(IBreadthFirstSearch searchMechanism, string start, string destination, int valueLimit)
        {
            var nodeStart = RailRoad.getNode(char.Parse(start));
            var nodeDestination = RailRoad.getNode(char.Parse(destination));
            return searchMechanism.find(nodeStart, nodeDestination, valueLimit);
        }
    }
}