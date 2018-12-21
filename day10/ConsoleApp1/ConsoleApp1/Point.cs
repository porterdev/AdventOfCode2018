using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Point
    {
        public Tuple<int,int> Position { get; set; }
        public Tuple<int, int> Velocity { get; set; }

        public Point(string input)
        {
            //expecting format:
            //position=< 9,  1> velocity=< 0,  2>
            //position=<-3, 11> velocity=< 1, -2>

            //let's strip the whitespaces
            //position=<9,1>velocity=<0,2>
            //position=<-3,11>velocity=<1,-2>
            input = input.Replace(" ", string.Empty);
         

            //parse with a regex
            Regex regex = new Regex("^position=<(-?\\d+),(-?\\d+)>velocity=<(-?\\d+),(-?\\d+)>$");
            Match match = regex.Match(input);
            var positionX = match.Groups[1].Value;
            var positionY = match.Groups[2].Value;
            var velocityX = match.Groups[3].Value;
            var velocityY = match.Groups[4].Value;

            Position = new Tuple<int, int>(int.Parse(positionX), int.Parse(positionY));
            Velocity = new Tuple<int, int>(int.Parse(velocityX), int.Parse(velocityY));
        }

        public void Iterate()
        {
            Position = new Tuple<int,int>(Position.Item1 + Velocity.Item1, Position.Item2 + Velocity.Item2);
        }

        public void Reverse()
        {
            Position = new Tuple<int, int>(Position.Item1 - Velocity.Item1, Position.Item2 - Velocity.Item2);
        }
    }
}
