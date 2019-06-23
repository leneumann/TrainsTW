using Trains.Domain.RailRoad;

namespace Trains.Domain.Algorithms
{
    public interface IBreadthFirstSearch
    {
        int find(Node start, Node destination, int valueLimit);
    }
}