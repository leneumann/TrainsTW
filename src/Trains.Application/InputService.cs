using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Trains.Domain;

namespace Trains.Application
{
    public interface IInputService
    {
        Input handle(string input);
    }
    public class InputService : IInputService
    {
        public Input handle(string input)
        {
            string cleanInput = removeEmptySpaces(input);
            string[] inputNodes = splitNodes(cleanInput);
            IOrderedEnumerable<char> nodes = getNodesFromInput(inputNodes);
            return new Input(inputNodes, nodes);
        }

        private string[] splitNodes(string cleanInput)
        {
            return cleanInput.Split(",");
        }

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

        private string removeEmptySpaces(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    }
}