using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class GameSetup
    {
        public int Players { get; set; }
        public int Points { get; set; }

        public GameSetup()
        {

        }

        public GameSetup(string input)
        {
            //expecting of format:
            //10 players; last marble is worth 1618 points

            //parse with a regex
            Regex regex = new Regex("^(\\d+) players; last marble is worth (\\d+) points$");
            Match match = regex.Match(input);
            var players = match.Groups[1].Value;
            var points = match.Groups[2].Value;

            Players = Int32.Parse(players);
            Points = Int32.Parse(points);
        }
    }
}
