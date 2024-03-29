using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Trains.Infrastructure;
using Xunit;

namespace Trains.UnitTests.Domain.Algorithms
{
    public class NumberOfRoutesAtMaximumOfStopsTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        ILogger Logger;
        public NumberOfRoutesAtMaximumOfStopsTest()
        {
            Logger = new LoggerStandardOut();
            InputService = new InputService(Logger);
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }

        [Fact]
        public void givenStartAndDestinationShouldReturnTotalOfRoutesLimitedByNumberOfStops()
        {
            // Arrange
            var nodeStart = RailRoad.getNode(char.Parse("C"));
            var nodeDestination = RailRoad.getNode(char.Parse("C"));
            IBreadthFirstSearch exactlyStops = new NumberOfRoutesAtMaximumOfStops();

            // Act
            var actual = exactlyStops.find(nodeStart,nodeDestination,3);
            
            //Assert
            Assert.Equal(2,actual);
        }
    }
}