using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Marble
    {
        public int Value { get; set; }
        public Marble Previous { get; set; }
        public Marble Next { get; set; }

        public List<int> Walk(bool forwards)
        {
            var result = new List<int> {Value};

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
