using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Trains.Domain;
using Trains.Infrastructure;

namespace Trains.Application
{
    public interface IInputService
    {
        Input handle(string input);
    }
    public class InputService : IInputService
    {
        public const string FORMATEXCEPTIONMESSAGE = "Invalid Format";

        public ILogger Logger { get; }

        public InputService(ILogger logger)
        {
            Logger = logger;
        }
        public Input handle(string input)
        {
            string cleanInput;
            string[] splitedInput;
            IOrderedEnumerable<char> nodes;
            try
            {
                cleanInput = removeEmptySpaces(input);
                splitedInput = splitInput(cleanInput);
                validateSplitedInput(splitedInput);
                nodes = getNodesFromInput(splitedInput);
            }
            catch (FormatException formatException)
            {
                Logger.error(formatException.Message);
                throw formatException;
            }
            catch (ArgumentNullException nullException)
            {
                Logger.error(nullException.Message);
                throw nullException;
            }
            catch (Exception exception)
            {
                Logger.fatal(exception.Message);
                throw exception;
            }
            return new Input(splitedInput, nodes);
        }

        private string[] splitInput(string cleanInput) => cleanInput.Split(",");


        private IOrderedEnumerable<char> getNodesFromInput(string[] inputNodes)
        {
            List<char> nodesList = new List<char>();
            for (int i = 0; i < inputNodes.Length; i++)
            {
                var inputNode = inputNodes[i];
                var firstletter = inputNode[0];
                var secondletter = inputNode[1];
                nodesList.Add(firstletter);
                nodesList.Add(secondletter);
            }
            return nodesList.Distinct().OrderBy(x => x);
        }

        private string removeEmptySpaces(string input) => Regex.Replace(input, @"\s+", "");
        public void validateSplitedInput(string[] splitedInput)
        {
            if (!inputIsValid(splitedInput))
                throw new FormatException(FORMATEXCEPTIONMESSAGE);
        }
        private bool inputIsValid(string[] splitedInput)
        {
            var pattern = "^[a-zA-Z0-9 ]*$";
            for (int i = 0; i < splitedInput.Length; i++)
            {
                if (!Regex.IsMatch(splitedInput[i], pattern))
                    return false;
                if (splitedInput[i].Count() > 3)
                    return false;
            }
            return true;
        }
    }
}