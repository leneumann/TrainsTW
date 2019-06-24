using System;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Trains.Infrastructure;

namespace Trains.Application
{
    public interface ILengthOfTheShortestRouteService
    {
        int get(IShortestPathSearch shortestPath, string start, string destination);
    }
    public class LengthOfTheShortestRouteService : ILengthOfTheShortestRouteService
    {
        private Graph RailRoad { get; }
        public ILogger Logger { get; }

        public LengthOfTheShortestRouteService(Graph railRoad, ILogger logger)
        {
            RailRoad = railRoad;
            Logger = logger;
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
                Logger.error(formatException.Message);
                throw formatException;
            }
            catch (Exception exception)
            {
                Logger.fatal(exception.Message);
                throw exception;
            }
            return shortestPath.find(RailRoad, nodeStart, nodeDestination);
        }
    }
}