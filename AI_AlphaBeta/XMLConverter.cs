using AI_AlphaBeta.Model;
using System.Collections.Generic;
using System.Xml;

namespace AI_AlphaBeta
{
    //util class to convert an XML to a tree
    //works with recursive exploration of xmlElements
    //use the System.Xml library
    public class XMLConverter
    {
        //the constructed tree
        static private Tree Tree;

        //the only public method, give the path of the xml
        public static Tree ConvertXMLtoTree(string pathXML)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathXML);
            Tree = new Tree();
            var enumerator = doc.DocumentElement.ChildNodes.GetEnumerator();
            if (enumerator.MoveNext()) Tree.Root = ConvertNode((enumerator.Current as XmlElement), null);
            return Tree;
        }

        //add the node to the tree and calls itself for every children of the current node
        private static Node ConvertNode(XmlElement xmlElement, Node node)
        {
            if (!string.IsNullOrWhiteSpace(xmlElement.GetAttribute("value")))
                node = new Node(int.Parse(xmlElement.GetAttribute("value")));
            else node = new Node(null);

            if (node.Children == null) node.Children = new List<Node>();

            if (xmlElement.HasChildNodes)
            {
                var enumerator = xmlElement.ChildNodes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var children = ConvertNode(enumerator.Current as XmlElement, node);
                    node.Children.Add(children);
                }
            }
            return node;
        }

    }
}
