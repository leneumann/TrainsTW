using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Xunit;

namespace Trains.UnitTests.Domain.Algorithms
{
    public class NumberOfRoutesWithExactlyStopsTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        public NumberOfRoutesWithExactlyStopsTest()
        {
            InputService = new InputService();
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }

        [Fact]
        public void givenStartAndDestinationShouldReturnTotalOfRoutesWithExactlyNumberOfStops()
        {
            // Arrange
            var nodeStart = RailRoad.getNode(char.Parse("A"));
            var nodeDestination = RailRoad.getNode(char.Parse("C"));
            IBreadthFirstSearch exactlyStops = new NumberOfRoutesWithExactlyStops();

            // Act
            var actual = exactlyStops.find(nodeStart,nodeDestination,4);
            
            //Assert
            Assert.Equal(3,actual);
        }
    }
}