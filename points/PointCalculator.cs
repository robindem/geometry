using System;

namespace points
{
    public class PointCalculator
    {
        public Point LargestXValue(Point[] input)
        {
            if (input.Length == 0) return null;

            Point Xmax = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                Point point = input[i];
                if (point.Xvalue > Xmax.Xvalue)
                {
                    Xmax = point;
                }
            }

            return Xmax;
        }

        public Point LargestYValue(Point[] input)
        {
            if (input.Length == 0) return null;

            Point Ymax = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                Point point = input[i];
                if (point.Yvalue > Ymax.Yvalue)
                {
                    Ymax = point;
                }
            }

            return Ymax;
        }

        public Point SmallestXValue(Point[] input)
        {
            if (input.Length == 0) return null;

            Point Xmin = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                Point point = input[i];
                if (point.Xvalue < Xmin.Xvalue)
                {
                    Xmin = point;
                }
            }

            return Xmin;
        }

        public Point SmallestYValue(Point[] input)
        {
            if (input.Length == 0) return null;

            Point Ymin = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                Point point = input[i];
                if (point.Yvalue < Ymin.Xvalue)
                {
                    Ymin = point;
                }
            }

            return Ymin;
        }

        public Envelope FindEnvelope(Point[] input)
        {
            if (input.Length < 2) return null;

            double Xmax = input[0].Xvalue;
            double Xmin = input[0].Xvalue;
            double Ymax = input[0].Yvalue;
            double Ymin = input[0].Yvalue;

            foreach (Point working in input)
            {
                if (working.Xvalue > Xmax)
                    Xmax = working.Xvalue;
                if (working.Xvalue < Xmin)
                    Xmin = working.Xvalue;
                if (working.Yvalue > Ymax)
                    Ymax = working.Yvalue;
                if (working.Yvalue < Ymin)
                    Ymin = working.Yvalue;
            }

            Envelope newEnvelope = new Envelope(Xmax, Xmin, Ymax, Ymin);
            return newEnvelope;
        }

        public double DistBtwPoints(Point point, Point query)
        {
            double a = query.Xvalue - point.Xvalue;
            double b = query.Yvalue - point.Yvalue;
            return Math.Sqrt(a * a + b * b);
        }

        public Point ClosestPoint(Point[] array, Point query)
        {
            Point closest = array[0];
            double distMin = DistBtwPoints(array[0], query);

            foreach (Point point in array)
            {
                double dist = DistBtwPoints(point, query);
                if (dist < distMin)
                {
                    distMin = dist;
                    closest = point;
                }
            }

            return closest;
        }

        public Point[] TwoClosestPoints(Point[] array)
        {
            if (array.Length < 1) return null;

            Point[] result = new Point[] { array[0], array[1] };

            double distMin = DistBtwPoints(array[0], array[1]);

            foreach (Point outerPoint in array)
            {
                foreach (Point innerPoint in array)
                {
                    if (outerPoint != innerPoint)
                    {
                        double distance = DistBtwPoints(outerPoint, innerPoint);

                        if (distance < distMin)
                        {
                            distMin = distance;
                            result[0] = outerPoint;
                            result[1] = innerPoint;
                        }
                    }

                }
            }
            return result;
        }

        public Point[] TwoFarthestPoints(Point[] array)
        {
            if (array.Length < 1) return null;

            Point[] result = new Point[] { array[0], array[1] };

            double distMax = DistBtwPoints(array[0], array[1]);

            foreach (Point outerPoint in array)
            {
                foreach (Point innerPoint in array)
                {
                    if (outerPoint != innerPoint)
                    {
                        double distance = DistBtwPoints(outerPoint, innerPoint);

                        if (distance > distMax)
                        {
                            distMax = distance;
                            result[0] = outerPoint;
                            result[1] = innerPoint;
                        }
                    }

                }
            }

            return result;
        }

        public Point CenterPoint(Point[] array)
        {
            if (array.Length == 0)
            {
                return null;
            }

            if (array.Length == 1)
            {
                return array[0];
            }

            Envelope box = FindEnvelope(array);

            double xcenter = ((box.Xmax - box.Xmin) / 2) + box.Xmin;

            double ycenter = ((box.Ymax - box.Ymin) / 2) + box.Ymin;

            Point center = new Point(xcenter, ycenter);

            return center;
        }
    }
}
