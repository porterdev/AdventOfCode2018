using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static string Process(string input)
        {
            var list = input.ToCharArray().ToList();

            for (int i = 0; i < list.Count - 1; i++)
            {
                //difference between lower and upper case chars is 32
                if (Math.Abs(list[i] - list[i+1]) == 32)
                {
                    //remove from list
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    //go back and start again
                    i = -1;
                }
                
            }

            return string.Concat(list);
        }
    }
}
