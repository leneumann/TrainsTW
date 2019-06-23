using System.Linq;

namespace Trains.Domain
{
    public class Input
    {
        private readonly string[] InputNodes;
        private readonly IOrderedEnumerable<char> Nodes;
        public Input(string[] inputNodes, IOrderedEnumerable<char> nodes)
        {
            InputNodes = inputNodes;
            Nodes = nodes;
        }
        public string[] getInputNodes() => InputNodes;
        public IOrderedEnumerable<char> getFoundNodes() => Nodes;
    }
}