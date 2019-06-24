using System;
using Trains.Application;
using Trains.Domain;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Xunit;

namespace Trains.UnitTests.Application
{
    public class DistanceOfTheRouteServiceTest
    {
        IInputService InputService;
        Input Input;
        Graph RailRoad;
        public DistanceOfTheRouteServiceTest()
        {
            InputService = new InputService();
            Input = InputService.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            RailRoad = Graph.createGraph(Input);
        }
        [Fact]
        public void givenValidInputShouldReturnDistanceOfTheRoute()
        {
            // Arrange
            IStepsSearch stepsSearch = new DistanceOfTheRoute();
            IDistanceOfTheRouteService distance = new DistanceOfTheRouteService(RailRoad);

            // Act
            var outPut = distance.get(stepsSearch, "A", "B", "C");

            // Assert
            Assert.Equal("9", outPut);
        }
        [Fact]
        public void givenInvalidInputShouldReturnFormatException()
        {
            // Arrange
            IStepsSearch stepsSearch = new DistanceOfTheRoute();
            IDistanceOfTheRouteService distance = new DistanceOfTheRouteService(RailRoad);

            // Assert
            Assert.Throws<FormatException>(() => distance.get(stepsSearch, "ABC"));
        }
        [Fact]
        public void givenNonExistentInputShouldReturnFormatException()
        {
            // Arrange
            IStepsSearch stepsSearch = new DistanceOfTheRoute();
            IDistanceOfTheRouteService distance = new DistanceOfTheRouteService(RailRoad);
            
            // Act
            var outPut = distance.get(stepsSearch, "F");

            // Assert
            Assert.Equal("ROUTE NOT FOUND", outPut);
        }
    }
}