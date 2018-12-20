using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static Node GetTree(List<int> data, ref int index)
        {
            var qtyChildren = data[index];
            var qtyMetaData = data[index + 1];

            var node = new Node();

            index += 2;
            for (int i = 0; i < qtyChildren; i++)
            {
                var childNode = GetTree(data, ref index);
                node.Children.Add(childNode);
            }

            for (int i = 0; i < qtyMetaData; i++)
            {
                node.MetaData.Add(data[index]);
                index++;
            }

            return node;
        }

        public static int GetSumMetadata(Node node)
        {
            var sum = 0;
            //traverse the tree
            sum += node.MetaData.Sum();

            foreach (var child in node.Children)
            {
                sum += GetSumMetadata(child);
            }

            return sum;
        }

        public static int GetNodeValue(Node node)
        {
            var value = 0;
            // traverse the tree based on metadata...

            if (node.Children.Count > 0)
            {
                //if the node has children, look at the metadata and get the appropriate child values
                foreach (var x in node.MetaData)
                {
                    //metadata is 1-based, so subtract 1 to make 0-based
                    var index = x - 1;
                    if (index < node.Children.Count)
                    {
                        value += GetNodeValue(node.Children[index]);
                    }
                }
            }
            else
            {
                //if the node has no children, then sum the metadata
                value += node.MetaData.Sum();
            }

            return value;
        }
    }
}
