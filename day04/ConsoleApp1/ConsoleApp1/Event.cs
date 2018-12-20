using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleApp1
{
    public class Event
    {
        public DateTime Date { get; set; }
        public Int64 Id { get; set; }

        public bool[] Asleep { get; private set; }


        public Event()
        {
            Asleep = new bool[60];
        }

    }
}
