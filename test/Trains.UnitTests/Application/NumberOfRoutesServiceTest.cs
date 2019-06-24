using System;
using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Xunit;

namespace Trains.UnitTests.Application
{
    public class NumberOfRoutesServiceTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        public NumberOfRoutesServiceTest()
        {
            InputService = new InputService();
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }
        [Fact]
        public void givenValidParametersGetNumberOfRoutesAtMaximumOfStops()
        {
            // Arrange
            IBreadthFirstSearch maxOfStops = new NumberOfRoutesAtMaximumOfStops();
            INumberOfRoutesService bfsService = new NumberOfRoutesService(RailRoad);

            // Act
            var outPut6 = bfsService.get(maxOfStops, "C", "C", 3);

            // Assert
            Assert.Equal(2, outPut6);
        }
        [Fact]
        public void givenValidParametersGetNumberOfRoutesWithExactlyStops()
        {
            // Arrange
            IBreadthFirstSearch exactlyStops = new NumberOfRoutesWithExactlyStops();
            INumberOfRoutesService bfsService = new NumberOfRoutesService(RailRoad);

            // Act
            var outPut7 = bfsService.get(exactlyStops, "A", "C", 4);

            // Assert
            Assert.Equal(3, outPut7);
        }
        [Fact]
        public void givenValidParametersGetNumberOfRoutesByDistance()
        {
            // Arrange
            IBreadthFirstSearch routesByDistance = new NumberOfRoutesByDistance();
            INumberOfRoutesService bfsService = new NumberOfRoutesService(RailRoad);

            // Act
            var outPut10 = bfsService.get(routesByDistance, "C", "C", 30);

            // Assert
            Assert.Equal(7, outPut10);
        }
        [Fact]
        public void givenInvalidInputShouldReturnFormatException()
        {
            // Arrange
            IBreadthFirstSearch maxOfStops = new NumberOfRoutesAtMaximumOfStops();
            INumberOfRoutesService bfsService = new NumberOfRoutesService(RailRoad);

            // Assert
            Assert.Throws<FormatException>(() => bfsService.get(maxOfStops, "ABC", "CDE", 3));
        }
    }
}