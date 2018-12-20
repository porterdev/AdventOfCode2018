using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace UnitTestProject1
{
    public static class Utils
    {
        public static Marble BuildCircle(int count)
        {
            var marble = new Marble { Value = 0 };
            marble.Previous = marble;
            marble.Next = marble;

            var prev = marble;
            for (int i = 0; i < count; i++)
            {
                var temp = new Marble
                {
                    Value = i + 1,
                    Previous = prev,
                    Next = marble
                };
                temp.Previous.Next = temp;
                prev = temp;
            }

            marble.Previous = prev;
            return marble;
        }
    }
}
