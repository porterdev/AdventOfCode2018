using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Functions
    {
        public static Claim GetClaim(string input)
        {
            //claim is of the format "#(id) @ (X),(Y): (width)x(height)"
            //e.g. "#1 @ 1,3: 4x5"
            Regex regex = new Regex("^#(\\d*) @ (\\d*),(\\d*): (\\d*)x(\\d*)$");
            Match match = regex.Match(input);
            var id = match.Groups[1].Value;
            var x = match.Groups[2].Value;
            var y = match.Groups[3].Value;
            var width = match.Groups[4].Value;
            var height = match.Groups[5].Value;

            return new Claim
            {
                Id = int.Parse(id),
                X = int.Parse(x),
                Y = int.Parse(y),
                Width = int.Parse(width),
                Height = int.Parse(height)
            };
        }
    }
}
