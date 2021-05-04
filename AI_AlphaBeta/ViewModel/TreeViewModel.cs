using AI_AlphaBeta.Model;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Diagrams.Core;

namespace AI_AlphaBeta.ViewModel
{
    public class TreeViewModel : IGraphSource
    {
        // current xPosition of the node
        private double xCounter;

        //current yPosition of the node
        private double yCounter;

        public TreeViewModel(Tree tree)
        {
            //we initialize the two lists of items and links between items
            Items = new ObservableCollection<NodeViewModel>();
            Links = new ObservableCollection<LinkViewModel>();

            //we initialize x and y at 10 pixel away from the top left corner
            xCounter = 10;
            yCounter = 10;

            if (tree != null && tree.Root != null) AddNode(tree.Root);
        }

        // update the treeViewModel
        public void UpdateTree(Tree tree)
        {
            xCounter = 10;
            yCounter = 10;
            Items.Clear();
            Links.Clear();
            if (tree != null && tree.Root != null) AddNode(tree.Root);
        }

        // recursive function
        //add the current node to the items list
        //and calls itself for every children of the node
        private void AddNode(Node node)
        {
            var nodeViewModel = new NodeViewModel(node, xCounter, yCounter);
            Items.Add(nodeViewModel);
            if(node.Children != null && node.Children.Count > 0)
            {
                yCounter += 70;
                foreach (var child in node.Children)
                {
                    Links.Add(new LinkViewModel(nodeViewModel, new NodeViewModel(child, xCounter, yCounter)));
                    AddNode(child);
                    xCounter += 70;
                }
                xCounter -= 70;
                yCounter -= 70;
            }
        }

        public ObservableCollection<NodeViewModel> Items { get; set; }

        public ObservableCollection<LinkViewModel> Links{ get; set; }

        IEnumerable<ILink> IGraphSource.Links => Links;

        IEnumerable IGraphSource.Items => Items;

        //return the number of visited nodes
        public int NbVisitedNode()
        {
            return Items.Where(e => e.Node.WentIn).ToList().Count;
        }

    }
}
