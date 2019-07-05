namespace points
{
    public class Program
    {
        static void Main(string[] args)
        {
            PointsProcessor testPoint = new PointsProcessor(@"C:\Users\robin\Documents\code\points\points.txt");
            PointCalculator testPoints = new PointCalculator();
            EnvelopeCalculator testEnvelope = new EnvelopeCalculator();
            //testPoint.ReadPointSetFromFile(); 

            Point first = new Point(1,1);
            Point second = new Point(1,3);
            Point third = new Point(4,5);
            Point fourth = new Point(7,8);
            Point fifth = new Point(10,2);
            Point sixth = new Point(7,12);
            Point seventh = new Point(1,4);
            Point[] mewArr = new Point[] { first, second, third, fourth, fifth, sixth };
            // Envelope envelope = testPoints.FindEnvelope(mewArr);

            // bool answer = testEnvelope.ContainsPoint(fourth, envelope);

            // testPoint.WritePointToFile(mewArr);

            //double dist = testPoints.DistBtwPoints(first, fourth);

            Point closest = testPoints.ClosestPoint(mewArr, seventh);
        }
    }
}
