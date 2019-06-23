using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;

namespace Trains.Application
{
    public interface IRailRoadService
    {
        string getDistanceOfTheRoute(string steps);
        int getNumberOfRoutesAtMaximumOfStops(string start, string destination, int levelLimit);
        int getNumberOfRoutesWithExactlyStops(string start, string destination, int levelLimit);
        int getLengthOfTheShortestRoute(string start, string destination);
        int getNumberOfRoutesByDistance(string start, string destination, int distanceLimit);
    }
    public class RailRoadService : IRailRoadService
    {
        private Graph RailRoad;

        public RailRoadService(Input input)
        {
            RailRoad = Graph.createGraph(input);
        }
        public string getDistanceOfTheRoute(string steps)
        {
            var split = steps.Split("-");
            Node[] nodes = new Node[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                nodes[i] = RailRoad.getNode(char.Parse(split[i]));
            }
            IStepsSearch stepsSearch = new DistanceOfTheRoute();
            return stepsSearch.find(nodes);
        }

        public int getLengthOfTheShortestRoute(string start, string destination)
        {
            IShortestPathSearch shortestPath = new LengthOfTheShortestRoute();
            var nodeStart = RailRoad.getNode(char.Parse(start));
            var nodeDestination = RailRoad.getNode(char.Parse(destination));
            return shortestPath.find(RailRoad, nodeStart, nodeDestination);   
        }

        public int getNumberOfRoutesAtMaximumOfStops(string start, string destination, int levelLimit)
        {
            IBreadthFirstSearch breadthSearch = new NumberOfRoutesAtMaximumOfStops();
            var nodeStart = RailRoad.getNode(char.Parse(start));
            var nodeDestination = RailRoad.getNode(char.Parse(destination));
            return breadthSearch.find(nodeStart, nodeDestination, levelLimit);
        }

        public int getNumberOfRoutesByDistance(string start, string destination, int distanceLimit)
        {
            IBreadthFirstSearch breadthSearch = new NumberOfRoutesByDistance();
            var nodeStart = RailRoad.getNode(char.Parse(start));
            var nodeDestination = RailRoad.getNode(char.Parse(destination));
            return breadthSearch.find(nodeStart, nodeDestination, distanceLimit);
        }

        public int getNumberOfRoutesWithExactlyStops(string start, string destination, int levelLimit)
        {
            IBreadthFirstSearch breadthSearch = new NumberOfRoutesWithExactlyStops();
            var nodeStart = RailRoad.getNode(char.Parse(start));
            var nodeDestination = RailRoad.getNode(char.Parse(destination));
            return breadthSearch.find(nodeStart, nodeDestination, levelLimit);
        }
    }
}