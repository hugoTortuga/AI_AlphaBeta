using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Diagrams.Core;

namespace AI_AlphaBeta.Model
{
    public class Tree : IGraphSource
    {
        public Node Root { get; set; }

        public IEnumerable<ILink> Links => throw new NotImplementedException();

        public IEnumerable Items => throw new NotImplementedException();

        public Tree()
        {
        }

    }
}
