using System;
using System.Collections.Generic;
using System.Linq;
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

        public static int CountDuplicateClaims(List<Claim> claims)
        {
            var fabric = new int[1000, 1000];
            var dupeClaimCount = 0;

            foreach (var claim in claims)
            {
                for (int x = 0; x < claim.Width; x++)
                {
                    for (int y = 0; y < claim.Height; y++)
                    {
                        fabric[claim.X + x, claim.Y + y]++;

                        //only check when equal to 2 as that's the first duplicate for this cell
                        if (fabric[claim.X + x, claim.Y + y] == 2)
                        {
                            dupeClaimCount++;
                        }
                    }
                }
            }

            return dupeClaimCount;
        }

        public static List<Claim> GetClaimsWithNoOverlap(List<Claim> claims)
        {
            var fabric = new List<Int64>[1000, 1000];

            //this will determine which claims claim each cell
            foreach (var claim in claims)
            {
                for (int x = 0; x < claim.Width; x++)
                {
                    for (int y = 0; y < claim.Height; y++)
                    {
                        var a = claim.X + x;
                        var b = claim.Y + y;
                        if (fabric[a, b] == null)
                        {
                            fabric[a, b] = new List<Int64>();
                        }
                        fabric[a, b].Add(claim.Id);
                    }
                }
            }

            //now get a list of all claim ids that clash
            var clashIds = new List<Int64>();
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (fabric[x, y] != null && fabric[x, y].Count > 1)
                    {
                        clashIds.AddRange(fabric[x,y]);
                    }
                }
            }

            var noOverlapClaims = claims.Where(x => !clashIds.Contains(x.Id)).ToList();

            return noOverlapClaims;
        }
    }
}
