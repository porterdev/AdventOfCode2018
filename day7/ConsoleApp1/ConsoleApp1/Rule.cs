using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Rule
    {
        public List<char> Requires { get; set; }

        public Rule()
        {
            Requires = new List<char>();
        }
    }
}
