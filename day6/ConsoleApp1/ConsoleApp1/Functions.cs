using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static Int32 GetManhattanDistance(Point source, Point dest)
        {
            //the taxicab distance between (p1,p2) and (q1,q2) is |p1-q1| + |p2-q2|

            var result = Math.Abs(source.X - dest.X) + Math.Abs(source.Y - dest.Y);

            return result;
        }

        public static Dictionary<Int32, Point> GetPoints(List<string> points)
        {
            //each point should be of the form "x, y" where x and y are numbers.

            var result = new Dictionary<Int32, Point>();

            var id = 0;
            foreach (var point in points)
            {
                var split = point.Split(',');
                var x = split[0].Trim();
                var y = split[1].Trim();

                result.Add(id, new Point(int.Parse(x), int.Parse(y)));
                id++;
            }

            return result;
        }

        public static int[,] GetBound(Dictionary<Int32, Point> points)
        {
            var maxX = points.Values.Select(x => x.X).Max();
            var maxY = points.Values.Select(x => x.Y).Max();
            var bound = new int[maxX + 1, maxY + 1];

            //go through all co-ordinates in the bound, finding their closest point
            for (int i = 0; i <= maxX; i++)
            {
                for (int j = 0; j <= maxY; j++)
                {
                    var minDistance = Int32.MaxValue;
                    var thisPoint = new Point(i, j);
                    foreach (var point in points)
                    {
                        var dist = Functions.GetManhattanDistance(thisPoint, point.Value);

                        if (dist == minDistance)
                        {
                            //two points have the same distance, neither may claim
                            bound[i, j] = -1;
                        }
                        if (dist < minDistance)
                        {
                            minDistance = dist;
                            bound[i, j] = point.Key;
                        }
                    }
                }
            }

            return bound;
        }

        public static Int32 GetLargestArea(Dictionary<Int32, Point> points)
        {
            var bound = GetBound(points);
            var maxX = bound.GetLength(0);
            var maxY = bound.GetLength(1);

            //now find the area for each point key
            var areas = new Dictionary<Int32, Int32>();

            foreach (var point in points)
            {
                areas.Add(point.Key, 0);
                for (int i = 0; i < maxX; i++)
                {
                    for (int j = 0; j < maxY; j++)
                    {
                        if (bound[i,j] == point.Key)
                        {
                            areas[point.Key]++;
                        }
                    }
                }
            }

            //determine which ids are on the outside bound
            var boundingIds = new List<Int32>();
            for (int i = 0; i < maxX; i++)
            {
                var id = bound[i, 0];
                if (!boundingIds.Contains(id))
                {
                    boundingIds.Add(id);
                }

                id = bound[i, maxY-1];
                if (!boundingIds.Contains(id))
                {
                    boundingIds.Add(id);
                }
            }

            for (int j = 0; j < maxY; j++)
            {
                var id = bound[0, j];
                if (!boundingIds.Contains(id))
                {
                    boundingIds.Add(id);
                }

                id = bound[maxX-1, j];
                if (!boundingIds.Contains(id))
                {
                    boundingIds.Add(id);
                }
            }

            //now remove any bounding ids from the list
            foreach (var id in boundingIds)
            {
                areas.Remove(id);
            }

            var largestArea = areas.Values.Max();
            return largestArea;



        }
    }
}
