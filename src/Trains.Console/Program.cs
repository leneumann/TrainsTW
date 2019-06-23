using System;
using Trains.Application;

namespace Trains.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputService inputS = new InputService();
            var input = inputS.handle("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            IRailRoadService rrs = new RailRoadService(input);
            var outPut1 = rrs.getDistanceOfTheRoute("A-B-C");
            var outPut2 = rrs.getDistanceOfTheRoute("A-D");
            var outPut3 = rrs.getDistanceOfTheRoute("A-D-C");
            var outPut4 = rrs.getDistanceOfTheRoute("A-E-B-C-D");
            var outPut5 = rrs.getDistanceOfTheRoute("A-E-D");
            var outPut6 = rrs.getNumberOfRoutesAtMaximumOfStops("C", "C", 3);
            var outPut7 = rrs.getNumberOfRoutesWithExactlyStops("A", "C", 4);
            var outPut8 = rrs.getLengthOfTheShortestRoute("A", "C");
            var outPut9 = rrs.getLengthOfTheShortestRoute("B", "B");
            var outPut10 = rrs.getNumberOfRoutesByDistance("C", "C", 30);
        }
    }
}
