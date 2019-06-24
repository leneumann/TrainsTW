using System;
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
            return searchMechanism.find(nodeStart, nodeDestination, valueLimit);
        }
    }
}