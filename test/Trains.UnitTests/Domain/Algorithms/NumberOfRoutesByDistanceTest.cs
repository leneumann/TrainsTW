using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Xunit;

namespace Trains.UnitTests.Domain.Algorithms
{
    public class NumberOfRoutesByDistanceTest
    {
        [Fact]
        public void givenStartAndDestinationShouldReturnTotalOfRoutesLimitedByDistance()
        {
            var A = new Node(char.Parse("A"));
            var B = new Node(char.Parse("B"));
            var C = new Node(char.Parse("C"));
            var D = new Node(char.Parse("D"));
            var E = new Node(char.Parse("E"));
            A.connectTo(B, 5);
            B.connectTo(C, 4);
            C.connectTo(D, 8);
            D.connectTo(C, 8);
            D.connectTo(E, 6);
            A.connectTo(D, 5);
            C.connectTo(E, 2);
            E.connectTo(B, 3);
            A.connectTo(E, 7);
            var numberOfRoutes = new NumberOfRoutesByDistance();
            var totalOfRoutes = numberOfRoutes.find(C,C,30);
            Assert.Equal(7,totalOfRoutes);
        }
    }
}