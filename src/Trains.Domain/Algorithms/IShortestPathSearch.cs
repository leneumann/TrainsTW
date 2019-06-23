using Trains.Domain.RailRoad;

namespace Trains.Domain.Algorithms
{
    public interface IShortestPathSearch
    {
        int find(Graph graph, Node start, Node Destination);
    }
}