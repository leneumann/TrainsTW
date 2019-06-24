using System;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Trains.Infrastructure;

namespace Trains.Application
{
    public interface IDistanceOfTheRouteService
    {
        string get(IStepsSearch searchMecanism, params string[] steps);
    }
    public class DistanceOfTheRouteService : IDistanceOfTheRouteService
    {
        private const string NOTFOUND = "ROUTE NOT FOUND";
        private Graph RailRoad;
        public DistanceOfTheRouteService(Graph graph, ILogger logger)
        {
            this.RailRoad = graph;
            Logger = logger;
        }

        public ILogger Logger { get; }

        public string get(IStepsSearch searchMecanism, params string[] steps)
        {
            Node[] nodes = new Node[steps.Length];
            try
            {
                for (int i = 0; i < steps.Length; i++)
                {
                    var node = RailRoad.getNode(char.Parse(steps[i]));
                    if (node == null)
                        return NOTFOUND;

                    nodes[i] = RailRoad.getNode(char.Parse(steps[i]));
                }
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

            return searchMecanism.find(nodes);
        }
    }
}