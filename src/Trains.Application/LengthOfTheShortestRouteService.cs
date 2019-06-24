using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;

namespace Trains.Application
{
    public class LengthOfTheShortestRouteService
    {
        private Graph RailRoad { get; }
        public LengthOfTheShortestRouteService(Graph railRoad)
        {
            RailRoad = railRoad;
        }

        public int get(IShortestPathSearch shortestPath, string start, string destination)
        {
            var nodeStart = RailRoad.getNode(char.Parse(start));
            var nodeDestination = RailRoad.getNode(char.Parse(destination));
            return shortestPath.find(RailRoad, nodeStart, nodeDestination);
        }
    }
}