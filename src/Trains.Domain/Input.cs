using System.Linq;

namespace Trains.Domain
{
    public class Input
    {
        private readonly string[] splitedInput;
        private readonly IOrderedEnumerable<char> Nodes;
        public Input(string[] inputNodes, IOrderedEnumerable<char> nodes)
        {
            splitedInput = inputNodes;
            Nodes = nodes;
        }
        public string[] getSplitedInput() => splitedInput;
        public IOrderedEnumerable<char> getFoundNodes() => Nodes;
    }
}