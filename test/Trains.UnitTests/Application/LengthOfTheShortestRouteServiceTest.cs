using System;
using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Xunit;

namespace Trains.UnitTests.Application
{
    public class LengthOfTheShortestRouteServiceTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        public LengthOfTheShortestRouteServiceTest()
        {
            InputService = new InputService();
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }
        [Fact]
        public void givenValidParametersGetLengthOfTheShortestRoute()
        {
            IShortestPathSearch shortestPath = new LengthOfTheShortestRoute();
            ILengthOfTheShortestRouteService shortestPathService = new LengthOfTheShortestRouteService(RailRoad);
            var outPut8 = shortestPathService.get(shortestPath, "A", "C");
            var outPut9 = shortestPathService.get(shortestPath, "B", "B");
            Assert.Equal(9, outPut8);
            Assert.Equal(9, outPut9);
        }

        [Fact]
        public void givenInvalidInputShouldReturnFormatException()
        {
            // Arrange
            IShortestPathSearch shortestPath = new LengthOfTheShortestRoute();
            ILengthOfTheShortestRouteService shortestPathService = new LengthOfTheShortestRouteService(RailRoad);

            // Assert
            Assert.Throws<FormatException>(() => shortestPathService.get(shortestPath, "ABC","CDE"));
        }
    }
}