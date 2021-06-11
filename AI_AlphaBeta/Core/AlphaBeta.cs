using AI_AlphaBeta.Model;

namespace AI_AlphaBeta.Core
{
    // it's the core class of the algorithm
    // works with recursive functions
    public class AlphaBeta
    {
        //exploration direction of the graph
        private static bool IsRightToLeft;

        //Main method, initialize the algorithm
        public static Tree FillTree(Tree emptyTree, bool isRightToLeft, bool isRootMax)
        {
            IsRightToLeft = isRightToLeft;
            if (emptyTree != null && emptyTree.Root != null)
            {
                // the recursive function fillNode, give the maximum for the root
                int max = FillNode(emptyTree.Root, -10000, 10000, isRootMax);
                emptyTree.Root.Value = max;
                emptyTree.Root.WentIn = true;
                // (you always visit the root)
            }
            return emptyTree;
        }

        private static int FillNode(Node node, int alpha, int beta, bool isMaxPlayer)
        {
            // if the node has no children return his value
            if (node.Children == null || node.Children.Count == 0) return node.Value.Value;

            //if the direction is lefttoright, i reverse the children list
            // as simple as that !
            if (!IsRightToLeft) node.Children.Reverse();

            //maximum to be taken
            if (isMaxPlayer)
            {
                int maxEval = -10000;

                foreach (var children in node.Children)
                {
                    //we say that we visited this node
                    children.WentIn = true;
                    //we call the function on the child
                    var value = FillNode(children, alpha, beta, !isMaxPlayer);
                    children.Value = value;
                    maxEval = Max(value, maxEval);
                    alpha = Max(alpha, value);
                    //if beta <= alpha, no need to go check on other children
                    if (beta <= alpha) break;
                }
                return maxEval;
            }
            //minimum to be taken
            else
            {
                int minEval = 10000;
                foreach (var children in node.Children)
                {
                    //we say that we visited this node
                    children.WentIn = true;
                    //we call the function on the child
                    var value = FillNode(children, alpha, beta, !isMaxPlayer);
                    children.Value = value;
                    minEval = Min(value, minEval);
                    beta = Min(beta, value);
                    //if beta <= alpha, no need to go check on other children
                    if (beta <= alpha) break;
                }
                return minEval;
            }
        }

        //simple function return the max value of two values
        private static int Max(int value1, int value2)
        {
            if (value1 > value2) return value1;
            else return value2;
        }

        //simple function return the min value of two values
        private static int Min(int value1, int value2)
        {
            if (value1 < value2) return value1;
            else return value2;
        }

    }
}
