using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_AlphaBeta.Model
{
    public class Node
    {
        // a nullable value
        public int? Value { get; set; }

        //boolean to say if the algorithm visited this node or not
        public bool WentIn { get; set; }

        public bool IsMax { get; set; }

        //each node can have a list of children nodes
        public List<Node> Children { get; set; }

        //constructor, initialize the value of the node
        //set null if parameter is null
        public Node(int? value)
        {
            if (value != null) Value = value.Value;
            else Value = null;

            WentIn = false;
            Children = new List<Node>();
        }

        public override string ToString()
        {
            return "" + Value;
        }
    }
}
