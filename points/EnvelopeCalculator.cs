using System;

namespace points
{
    public class EnvelopeCalculator
    {
        public bool ContainsPoint(Point value, Envelope shape)
        {
            if (value.Xvalue > shape.Xmin &&
                value.Xvalue < shape.Xmax &&
                value.Yvalue > shape.Ymin &&
                value.Yvalue < shape.Ymax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Envelope BufferEnvelope(Envelope envelope, float percent)
        {
            //make this more efficient. maybe a % calculator?
            double sizedXmax = envelope.Xmax * (1 + percent);
            double sizedXmin = envelope.Xmin * (1 + percent);
            double sizedYmax = envelope.Ymax * (1 + percent);
            double sizedYmin = envelope.Ymin * (1 + percent);

            Envelope newEnvelope = new Envelope(sizedXmax, sizedXmin, sizedYmax, sizedYmin);

            return newEnvelope;
        }

        public double EnvelopeArea(Envelope envelope)
        {
            double length = envelope.Xmax - envelope.Xmin;
            double width = envelope.Ymax - envelope.Ymin;

            double area = length * width;

            return area;
        }

        Envelope envelope = new Envelope(5, 1, 6, 2);
        int numPoints = 3;

        public Point[] randomPoints(Envelope envelope, int numPoints)
        {
            Random rand = new Random();

            Point[] randPoints = new Point[numPoints];

            for (int i = 0; i < numPoints; i++)
            {
                double xRand = rand.NextDouble() * (envelope.Xmax - envelope.Xmin) + envelope.Xmin;
                double yRand = rand.NextDouble() * (envelope.Ymax - envelope.Ymin) + envelope.Ymin;

                Point newPoint = new Point(xRand, yRand);
            }
//does this end up actually storing the newPoint in my randPoints array?

            return randPoints;
        }

    }
}
