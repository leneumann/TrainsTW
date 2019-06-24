using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Xunit;

namespace Trains.UnitTests.Domain.Algorithms
{
    public class NumberOfRoutesByDistanceTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        public NumberOfRoutesByDistanceTest()
        {
            InputService = new InputService();
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }
        [Fact]
        public void givenStartAndDestinationShouldReturnTotalOfRoutesLimitedByDistance()
        {
            //Arranje
            var nodeStart = RailRoad.getNode(char.Parse("C"));
            var nodeDestination = RailRoad.getNode(char.Parse("C"));
            var numberOfRoutes = new NumberOfRoutesByDistance();

            //Act
            var totalOfRoutes = numberOfRoutes.find(nodeStart, nodeDestination, 30);
            
            //Assert
            Assert.Equal(7, totalOfRoutes);
        }
    }
}