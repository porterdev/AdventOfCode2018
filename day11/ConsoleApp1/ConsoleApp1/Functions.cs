using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        private static readonly int[,] _powerLevels = new int[301, 301];
        private static readonly int[,] _partialSums = new int[301, 301];

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

        public static Tuple<int, int, int> DetermineHighestPowerLocation(int serial, int gridSize)
        {
            //grid of 300x300, location is a nxn grid, identified by the top-left co-ordinate
            //so we don't have to go higher than 300-n+1,300-n+1, e.g for n=3 we check up to 298,298
            var max = 300 - gridSize + 1;

            //x, y, power level
            var result = new Tuple<int, int, int>(0, 0, 0);

            for (int y = 1; y <= max; y++)
            {
                for (int x = 1; x <= max; x++)
                {
                    //for this location, determine the cells that make up this nxn grid
                    var thisPower = 0;

                    for (int i = 0; i < gridSize; i++)
                    {
                        for (int j = 0; j < gridSize; j++)
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

        public static Tuple<int, int, int, int> DetermineHighestPowerLocationForAllGrids(int serial)
        {
            //the biggest gridsize would be 300 - the whole area of 300x300

            //x, y, grid size, power level
            var result = new Tuple<int, int, int, int>(0, 0, 0, 0);

            //precalculate the power levels
            for (int y = 1; y <= 300; y++)
            {
                for (int x = 1; x <= 300; x++)
                {
                    _powerLevels[x, y] = CalculatePowerLevel(x, y, serial);
                }
            }

            //use the concept of partial sums, said the wise old wizard
            for (int y = 1; y <= 300; y++)
            {
                for (int x = 1; x <= 300; x++)
                {
                    _partialSums[x, y] = CalculatePartialSum(x, y, serial);               
                }
            }

            //go through all bottom-right co-ords possible, because then we can use our partial sums
            //to determine the best power level efficientlys
            for (int gridSize = 1; gridSize <= 300; gridSize++)
            {
                for (int y = gridSize; y <= 300; y++)
                {
                    for (int x = gridSize; x <= 300; x++)
                    {
                        var thisPower = _partialSums[x, y];
                        if (x - gridSize > 0)
                        {
                            thisPower -= _partialSums[x - gridSize, y];
                        }
                        if (y - gridSize > 0)
                        {
                            thisPower -= _partialSums[x, y - gridSize];
                        }
                        if ((x - gridSize > 0) && (y - gridSize > 0))
                        {
                            thisPower += _partialSums[x - gridSize, y - gridSize];
                        }

                        if (thisPower > result.Item4)
                        {
                            //the x,y we have is for the bottom right, we need the top left
                            //so subtract (gridSize-1) from the co-ords
                            result = new Tuple<int, int, int, int>(x - (gridSize - 1),
                                y - (gridSize - 1),
                                gridSize,
                                thisPower);
                        }
                    }
                }
            }

            return result;
        }

        private static int CalculatePartialSum(int x, int y, int serial)
        {
            var powerLevel = CalculatePowerLevel(x, y, serial);

            var partialSum = powerLevel + 
                _partialSums[x, y - 1] + 
                _partialSums[x - 1, y] - 
                _partialSums[x - 1, y - 1];

            return partialSum;

        }
    }
}
