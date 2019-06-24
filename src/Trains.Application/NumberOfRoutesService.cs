using System;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Trains.Infrastructure;

namespace Trains.Application
{
    public interface INumberOfRoutesService
    {
        int get(IBreadthFirstSearch searchMechanism, string start, string destination, int valueLimit);
    }
    public class NumberOfRoutesService : INumberOfRoutesService
    {
        public Graph RailRoad { get; }
        public ILogger Logger { get; }

        public NumberOfRoutesService(Graph railRoad, ILogger logger)
        {
            RailRoad = railRoad;
            Logger = logger;
        }

        public int get(IBreadthFirstSearch searchMechanism, string start, string destination, int valueLimit)
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
            return searchMechanism.find(nodeStart, nodeDestination, valueLimit);
        }
    }
}