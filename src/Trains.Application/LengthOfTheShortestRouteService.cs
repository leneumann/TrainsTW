using System;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;

namespace Trains.Application
{
    public interface ILengthOfTheShortestRouteService
    {
        int get(IShortestPathSearch shortestPath, string start, string destination);
    }
    public class LengthOfTheShortestRouteService : ILengthOfTheShortestRouteService
    {
        private Graph RailRoad { get; }
        public LengthOfTheShortestRouteService(Graph railRoad)
        {
            RailRoad = railRoad;
        }

        public int get(IShortestPathSearch shortestPath, string start, string destination)
        {
            Node nodeStart;
            Node nodeDestination;
            try
            {
                nodeStart = RailRoad.getNode(char.Parse(start));
                nodeDestination = RailRoad.getNode(char.Parse(destination));
            }
            catch (FormatException formatException)
            {
                throw formatException;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return shortestPath.find(RailRoad, nodeStart, nodeDestination);
        }
    }
}