using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static int IterateToSmallestArea(List<Point> points, int minIterations)
        {
            //we will keep iterating until the overall area no longer is shrinking
            var smallestArea = GetArea(points);
            var iterations = 0;

            foreach (var point in points)
            {
                point.Iterate();
            }

            var thisArea = GetArea(points);
            {
                while (thisArea < smallestArea || iterations < minIterations)
                {
                    iterations++;
                    smallestArea = thisArea;
                    foreach (var point in points)
                    {
                        point.Iterate();
                    }
                    thisArea = GetArea(points);
                }
            }

            //go back one iteration for the smallest area
            foreach (var point in points)
            {
                point.Reverse();
            }

            return iterations;
        }

        public static int GetArea(List<Point> points)
        {
            var minX = points.Select(x => x.Position.Item1).Min();
            var minY = points.Select(x => x.Position.Item2).Min();
            var maxX = points.Select(x => x.Position.Item1).Max();
            var maxY = points.Select(x => x.Position.Item2).Max();

            var area = (maxX - minX) * (maxY - minY);

            return area;
        }

        public static List<string> Visualize(List<Point> points)
        {
            var minX = points.Select(x => x.Position.Item1).Min();
            var minY = points.Select(x => x.Position.Item2).Min();
            var maxX = points.Select(x => x.Position.Item1).Max();
            var maxY = points.Select(x => x.Position.Item2).Max();

            Console.WriteLine("{0},{1}-{2},{3}", minX, minY, maxX, maxY);

            var result = new List<string>();
            var sb = new StringBuilder();
            for (int y = minY; y <= maxY; y++)
            {
                sb.Clear();
                for (int x = minX; x <= maxX; x++)
                {
                    if (points.Any(p => p.Position.Item1 == x && p.Position.Item2 == y))
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }
                result.Add(sb.ToString());
            }

            return result;
        }
    }
}
