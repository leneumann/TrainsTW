using Trains.Domain.RailRoad;

namespace Trains.Domain.Algorithms
{
    public interface IStepsSearch
    {
         string find(params Node[] steps);
    }
}