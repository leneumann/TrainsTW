using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Trains.Infrastructure;
using Xunit;

namespace Trains.UnitTests.Domain.Algorithms
{
    public class LengthOfTheShortestRouteTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        ILogger Logger;
        public LengthOfTheShortestRouteTest()
        {
            Logger = new LoggerStandardOut();
            InputService = new InputService(Logger);
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }

        [Fact]
        public void givenStartAndDestinationShouldReturnTheShortestRoute()
        {
           // Arrange
            var nodeStart = RailRoad.getNode(char.Parse("A"));
            var nodeDestination = RailRoad.getNode(char.Parse("C"));
            IShortestPathSearch shortestPath = new LengthOfTheShortestRoute();
            
           // Act
            var actual = shortestPath.find(RailRoad, nodeStart,nodeDestination);
           
           // Assert
           Assert.Equal(9, actual);
        }
    }
}