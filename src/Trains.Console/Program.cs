using System;
using Trains.Application;
using Trains.Domain.Algorithms;
using Trains.Domain.RailRoad;
using Trains.Infrastructure;

namespace Trains.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new LoggerStandardOut();
            validateInput(args,logger);
            IInputService inputService = new InputService(logger);
            IRailRoadService railRoadService = new RailRoadService();
            var input = inputService.handle(args[0]);
            var graph = railRoadService.createGraph(input);

            IStepsSearch stepsSearch = new DistanceOfTheRoute();
            IDistanceOfTheRouteService distance = new DistanceOfTheRouteService(graph, logger);
            var outPut1 = distance.get(stepsSearch, "A", "B", "C");
            var outPut2 = distance.get(stepsSearch, "A", "D");
            var outPut3 = distance.get(stepsSearch, "A", "D", "C");
            var outPut4 = distance.get(stepsSearch, "A", "E", "B", "C", "D");
            var outPut5 = distance.get(stepsSearch, "A", "E", "D");

            IBreadthFirstSearch maxOfStops = new NumberOfRoutesAtMaximumOfStops();
            IBreadthFirstSearch exactlyStops = new NumberOfRoutesWithExactlyStops();
            IBreadthFirstSearch routesByDistance = new NumberOfRoutesByDistance();
            INumberOfRoutesService bfsService = new NumberOfRoutesService(graph, logger);
            var outPut6 = bfsService.get(maxOfStops, "C", "C", 3);
            var outPut7 = bfsService.get(exactlyStops, "A", "C", 4);
            var outPut10 = bfsService.get(routesByDistance, "C", "C", 30);

            IShortestPathSearch shortestPath = new LengthOfTheShortestRoute();
            ILengthOfTheShortestRouteService shortestPathService = new LengthOfTheShortestRouteService(graph, logger);
            var outPut8 = shortestPathService.get(shortestPath, "A", "C");
            var outPut9 = shortestPathService.get(shortestPath, "B", "B");


            System.Console.WriteLine($" Output #1: {outPut1}");
            System.Console.WriteLine($" Output #2: {outPut2}");
            System.Console.WriteLine($" Output #3: {outPut3}");
            System.Console.WriteLine($" Output #4: {outPut4}");
            System.Console.WriteLine($" Output #5: {outPut5}");
            System.Console.WriteLine($" Output #6: {outPut6}");
            System.Console.WriteLine($" Output #7: {outPut7}");
            System.Console.WriteLine($" Output #8: {outPut8}");
            System.Console.WriteLine($" Output #9: {outPut9}");
            System.Console.WriteLine($" Output #10: {outPut10}");
        }
        public static void validateInput(string[] args, ILogger logger)
        {
            try
            {
            if(args.Length==0)
                throw new ArgumentException();
            }
            catch (ArgumentException argumentException)
            {
                logger.error(argumentException.Message);
                throw argumentException;
            }
        }
    }
}
