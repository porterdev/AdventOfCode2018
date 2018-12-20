using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Marble
    {
        public Int64 Value { get; set; }
        public Marble Previous { get; set; }
        public Marble Next { get; set; }

        public List<Int64> Walk(bool forwards)
        {
            var result = new List<Int64> {Value};

            if (forwards)
            {
                var currentMarble = Next;
                while (currentMarble.Value != this.Value)
                {
                    result.Add(currentMarble.Value);
                    currentMarble = currentMarble.Next;
                }
            }
            else
            {
                var currentMarble = Previous;
                while (currentMarble.Value != this.Value)
                {
                    result.Add(currentMarble.Value);
                    currentMarble = currentMarble.Previous;
                }
            }
         
            return result;
        }
    }
}
