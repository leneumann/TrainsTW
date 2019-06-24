namespace Trains.Domain.RailRoad
{
    public interface IRailRoadService
    {
        Graph createGraph(Input input);
    }
    public class RailRoadService : IRailRoadService
    {
        public Graph createGraph(Input input) => new Graph(input);
    }
}