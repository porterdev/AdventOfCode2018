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

        public bool[] Awake { get; private set; }


        public Event()
        {
            Awake = new bool[60];
        }

    }
}
