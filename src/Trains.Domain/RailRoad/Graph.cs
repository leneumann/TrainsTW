using System;
using System.Collections.Generic;

namespace Trains.Domain.RailRoad
{
    public class Graph
    {
        private List<Node> Nodes = new List<Node>();
        public Graph(Input input)
        {
            addNodes(input);
            var inputNodes = input.getInputNodes();
            addEdges(inputNodes);
        }

        private void addEdges(string[] inputNodes)
        {
            //lê cada parâmetro do input e separa para obter os nós e o peso, adicionando em um array
            for (int i = 0; i < inputNodes.Length; i++)
            {
                var parameter = inputNodes[i];
                var firstletter = parameter[0];
                var secondletter = parameter[1];
                var thirdletter = parameter[2];
                var nodeSource = getNode(firstletter);
                var nodeDestination = getNode(secondletter);
                int weight = (int)Char.GetNumericValue(thirdletter);
                nodeSource.connectTo(nodeDestination, weight);
            }
        }

        private void addNodes(Input input)
        {
            foreach (var item in input.getFoundNodes())
            {
                var node = Node.createNode(item);
                addNode(node);
            }
        }

        public static Graph createGraph(Input input) => new Graph(input);
        public List<Node> getListOfNodes() => Nodes;
        public Node getNode(char label) => Nodes.Find(x => x.Label == label);
        private void addNode(Node node)=> Nodes.Add(node);
    }
}