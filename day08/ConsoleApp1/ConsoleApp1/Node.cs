using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Node
    {
        public List<int> MetaData { get; set; }
        public List<Node> Children { get; set; }

        public Node()
        {
            MetaData = new List<int>();
            Children = new List<Node>();
        }
    }
}
