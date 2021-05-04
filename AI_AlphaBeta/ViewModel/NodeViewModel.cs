using AI_AlphaBeta.Model;
using System.Windows;

namespace AI_AlphaBeta
{

    //the node view model class, contains a node and a position
    public class NodeViewModel
    {

        public Node Node { get; set; }

        public Point Position { get; set; }

        public NodeViewModel(Node node, double x, double y)
        {
            Node = node;
            Position = new Point(x, y);
        }

        //toString : same as java
        public override string ToString()
        {
            return "" + Node.Value;
        }

    }
}
