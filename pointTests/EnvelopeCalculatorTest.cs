using System;
using points;
using Xunit;

namespace pointTests
{
    public class EnvelopeCalculatorTest
    {
        EnvelopeCalculator calculator = new EnvelopeCalculator();

        Envelope test1 = new Envelope(9, 1, 12, 3);
        Envelope test2 = new Envelope(-4, -2.0, 9.99999, -3.345);
        Point point1 = new Point(2, 7);
        Point point2 = new Point(-3.0, 0);

        [Fact]
        public void TestContainsPointOutside()
        {
            bool result = calculator.ContainsPoint(point2, test2);
            Assert.False(result);
        }

        [Fact]
        public void TestContainsPointInside()
        {
            bool result = calculator.ContainsPoint(point1, test1);
            Assert.True(result);
        }

        [Fact]
        public void TestBufferEnvelope()
        {
            Envelope points = new Envelope(13, -2, 3.5, -6.6);
            float percent = 0.7f;

            Envelope result = calculator.BufferEnvelope(points, percent);

            Assert.Equal(22.1, Math.Round(result.Xmax, 1));
            Assert.Equal(-3.4, Math.Round(result.Xmin, 1));
            Assert.Equal(5.95, Math.Round(result.Ymax, 2));
            Assert.Equal(-11.3, Math.Round(result.Ymin, 1));
        }

        [Fact]
        public void TestEnvelopeArea()
        {
            double result = calculator.EnvelopeArea(test1);
            Assert.Equal(72, result);
        }

        [Fact]
        public void TestRandomPoints()
        {
            Envelope envelope = new Envelope(5, 1, 6, 2);
            int numPoints = 3;

            Point[] result = calculator.randomPoints(envelope, numPoints);

            //loop through assertion, 
            //Assert.InRange(result, envelope.Xmin, envelope.Xmax);
        }
    }
}