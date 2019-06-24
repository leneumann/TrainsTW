using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;

namespace Trains.Application
{
    public class DistanceOfTheRouteService
    {
        private Graph RailRoad;
        public DistanceOfTheRouteService(Graph graph)
        {
            this.RailRoad = graph;
        }

        public string get(IStepsSearch searchMecanism,string steps)
        {
            var split = steps.Split("-");
            Node[] nodes = new Node[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                nodes[i] = RailRoad.getNode(char.Parse(split[i]));
            }
            return searchMecanism.find(nodes);
        }
    }
}