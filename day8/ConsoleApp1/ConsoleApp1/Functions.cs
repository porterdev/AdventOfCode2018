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
    }
}
