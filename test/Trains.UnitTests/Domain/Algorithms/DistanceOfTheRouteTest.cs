using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Trains.Infrastructure;
using Xunit;

namespace Trains.UnitTests.Domain.Algorithms
{
    public class DistanceOfTheRouteTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        ILogger Logger;
        public DistanceOfTheRouteTest()
        {
            Logger = new LoggerStandardOut();
            InputService = new InputService(Logger);
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }
        [Fact]
        public void givenValidRouteStopsShouldReturnTheDistance()
        {
            // Arrange
            var nodeStart = RailRoad.getNode(char.Parse("A"));
            var nodeStep = RailRoad.getNode(char.Parse("B"));
            var nodeDestination = RailRoad.getNode(char.Parse("C"));
            var distanceOfTheRoute = new DistanceOfTheRoute();

            //Act
            var actual = distanceOfTheRoute.find(nodeStart, nodeStep, nodeDestination);

            // Assert
            Assert.Equal("9",actual);
        }

        [Fact]
        public void givenInvalidRouteShouldReturnRouteNotFound()
        {
                        // Arrange
            var nodeStart = RailRoad.getNode(char.Parse("A"));
            var nodeStep = RailRoad.getNode(char.Parse("E"));
            var nodeDestination = RailRoad.getNode(char.Parse("D"));
            var distanceOfTheRoute = new DistanceOfTheRoute();

            //Act
            var actual = distanceOfTheRoute.find(nodeStart, nodeStep, nodeDestination);

            // Assert
            Assert.Equal("NO SUCH ROUTE",actual);
        }
    }
}