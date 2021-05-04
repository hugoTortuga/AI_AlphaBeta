using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Diagrams.Core;

namespace AI_AlphaBeta.ViewModel
{
    //link class, containing a source nodeviewmodel and a target nodeviewmodel
    public class LinkViewModel : ILink<NodeViewModel>
    {
        public LinkViewModel(NodeViewModel source, NodeViewModel target)
        {
            Source = source;
            Target = target;
            //i add 30 pixel to every coords of the point, because the node is 60 pixel large, 
            // and i want the link to start from the middle of the node
            var sourcePoint = new Point(source.Position.X + 30, source.Position.Y + 30);
            var targetPoint = new Point(target.Position.X + 30, target.Position.Y + 30);
            SourcePosition = sourcePoint;
            TargetPosition = targetPoint;

        }

        public Point SourcePosition { get; set; }
        public Point TargetPosition { get; set; }
        public NodeViewModel Source { get; set; }
        public NodeViewModel Target { get; set; }
        object ILink.Source { 
            get { return Source; } 
            set {} 
        }
        object ILink.Target { 
            get { return Target; } 
            set {} 
        }

        //no info needs to be printed on the link
        public override string ToString()
        {
            return ""; 
        }
    }
}
