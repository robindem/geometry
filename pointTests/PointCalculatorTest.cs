using points;
using Xunit;

namespace pointTests
{
    public class PointCalculatorTest
    {
        PointCalculator calculator = new PointCalculator();
        Point[] testArray = new Point[]
        {
            new Point(0, 0),
            new Point(1, 2),
            new Point(9.3,5.22),
            new Point(-99, 23.232),
            new Point(-9.982,-5.0),
            new Point(-10001.09882832,80039.8762682),
        };

        Point testPoint = new Point(5, 3);


        [Fact]
        public void TestLargestXValue()
        {
            Point result = calculator.LargestXValue(testArray);
            Assert.Equal(testArray[2], result);
        }

        [Fact]
        public void TestLargestXValueWithEmptyArray()
        {
            Point result = calculator.LargestXValue(new Point[] { });
            Assert.Null(result);
        }

        [Fact]
        public void TestLargestYValue()
        {
            Point result = calculator.LargestYValue(testArray);
            Assert.Equal(testArray[5], result);
        }

        [Fact]
        public void TestLargestYValueWithEmptyArray()
        {
            Point result = calculator.LargestYValue(new Point[] { });
            Assert.Null(result);
        }

        [Fact]
        public void TestSmallestXValue()
        {
            Point result = calculator.SmallestXValue(testArray);
            Assert.Equal(testArray[5], result);
        }

        [Fact]
        public void TestSmallestXValueWithEmptyArray()
        {
            Point result = calculator.SmallestXValue(new Point[] { });
            Assert.Null(result);
        }

        [Fact]
        public void TestSmallestYValue()
        {
            Point result = calculator.SmallestYValue(testArray);
            Assert.Equal(testArray[4], result);
        }

        [Fact]
        public void TestSmallestYValueWithEmptyArray()
        {
            Point result = calculator.SmallestYValue(new Point[] { });
            Assert.Null(result);
        }

        [Fact]
        public void TestFindEnvelope()
        {
            Envelope result = calculator.FindEnvelope(testArray);
            Assert.Equal(9.3, result.Xmax);
            Assert.Equal(-10001.09882832, result.Xmin);
            Assert.Equal(80039.8762682, result.Ymax);
            Assert.Equal(-5.0, result.Ymin);
        }

        [Fact]
        public void TestFindEnvelopeWithOnePoint()
        {
            Envelope result = calculator.FindEnvelope(new Point[] { testArray[1] });
            Assert.Null(result);
        }
        [Fact]
        public void TestFindEnvelopeWithTwoPoints()
        {
            Envelope result = calculator.FindEnvelope(new Point[] { testArray[1], testArray[2] });
            Assert.Equal(9.3, result.Xmax);
            Assert.Equal(1, result.Xmin);
            Assert.Equal(5.22, result.Ymax);
            Assert.Equal(2, result.Ymin);
        }

        [Fact]
        public void TestFindEnvelopeWithThreePoints()
        {
            Envelope result = calculator.FindEnvelope(new Point[] { testArray[3], testArray[4], testArray[2] });
            Assert.Equal(9.3, result.Xmax);
            Assert.Equal(-99, result.Xmin);
            Assert.Equal(23.232, result.Ymax);
            Assert.Equal(-5, result.Ymin);
        }

        [Fact]
        public void TestDistBtwPoints()
        {
            double result = calculator.DistBtwPoints(testArray[0], testArray[1]);
            Assert.Equal(2.23606797749979, result);
        }

        [Fact]
        public void TestClosestPoint()
        {
            Point result = calculator.ClosestPoint(testArray, testPoint);
            Assert.Equal(testArray[1], result);
        }

        [Fact]
        public void TestTwoClosestPoints()
        {
            Point[] minitestArray = new Point[]
            {
                new Point(-99, 23.232),
                new Point(1, 2),
                new Point(20,-35.0),
                new Point(9.3,5.22),
                new Point(10,6),
                new Point(-10001.09882832,80039.8762682),
            };

            Point[] result = calculator.TwoClosestPoints(minitestArray);
            Assert.Equal(minitestArray[3], result[0]);
            Assert.Equal(minitestArray[4], result[1]);
        }

        [Fact]
        public void TestTwoClosestPointsEqualXY()
        {
            Point[] minitestArray = new Point[]
            {
                new Point(-99, 23.232),
                new Point(1, 2),
                new Point(20,-35.0),
                new Point(10,6),
                new Point(10,6),
                new Point(-10001.09882832,80039.8762682),
            };

            Point[] result = calculator.TwoClosestPoints(minitestArray);
            Assert.Equal(minitestArray[3], result[0]);
            Assert.Equal(minitestArray[4], result[1]);
        }
        [Fact]
        public void TestTwoFarthestPoints()
        {
            Point[] minitestArray = new Point[]
            {
                new Point(7, 23.232),
                new Point(1, 2),
                new Point(20, 35.0),
                new Point(9.3, 5.22),
                new Point(1000, 1000),
            };

            Point[] result = calculator.TwoFarthestPoints(minitestArray);
            Assert.Equal(minitestArray[1], result[0]);
            Assert.Equal(minitestArray[4], result[1]);
        }

        [Fact]
        public void TestCenterPoint()
        {
            Point[] centerTestArray = new Point[]
            {
                new Point(3, 6),
                new Point(10, 2),
                new Point(4, 7),
                new Point(8, 12)
            };
            Point result = calculator.CenterPoint(centerTestArray);
            Assert.Equal(6.5, result.Xvalue);
            Assert.Equal(7, result.Yvalue);
        }

        [Fact]
        public void TestCenterPointOnePoint()
        {
            Point[] lonlyTestAray = new Point[]
            {
                new Point(4, 7)
            };
            Point result = calculator.CenterPoint(lonlyTestAray);
            Assert.Equal(4, result.Xvalue);
            Assert.Equal(7, result.Yvalue);
        }

        [Fact]
        public void TestCenterNoPoint()
        {
            Point[] emptyArray = new Point[]
            {

            };
            Point result = calculator.CenterPoint(emptyArray);
            Assert.Null(result);
        }


    }
}
