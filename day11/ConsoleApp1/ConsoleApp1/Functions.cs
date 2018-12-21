using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static int CalculatePowerLevel(int x, int y, int serial)
        {
            // Find the fuel cell's rack ID, which is its X coordinate plus 10.
            var rackId = x + 10;

            // Begin with a power level of the rack ID times the Y coordinate.
            var powerLevel = rackId * y;

            // Increase the power level by the value of the grid serial number (your puzzle input).
            powerLevel += serial;

            // Set the power level to itself multiplied by the rack ID.
            powerLevel *= rackId;

            // Keep only the hundreds digit of the power level (so 12345 becomes 3; numbers with no hundreds digit become 0).
            // mod 1000 to get a number between 0 and 999, then divide by 100
            powerLevel %= 1000;
            powerLevel /= 100;

            // Subtract 5 from the power level.
            powerLevel -= 5;

            return powerLevel;
        }

        public static Tuple<int, int, int> DetermineHighestPowerLocation(int serial)
        {
            //grid of 300x300, location is a 3x3 grid, identified by the top-left co-ordinate
            //so we don't have to go higher than 298,298

            //x, y, power level
            var result = new Tuple<int, int, int>(0, 0, 0);

            for (int y=1; y<=298; y++)
            {
                for (int x = 1; x <= 298; x++)
                {
                    //for this location, determine the 9 cells that make up this 3x3 grid
                    var thisPower = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            thisPower += CalculatePowerLevel(x + i, y + j, serial);
                        }
                    }

                    if (thisPower > result.Item3)
                    {
                        result = new Tuple<int, int, int>(x, y, thisPower);
                    }
                }
            }

            return result;
        }
    }
}
