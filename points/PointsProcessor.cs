using System.IO;

namespace points
{
    public class PointsProcessor
    {
        public string FileName;

        public PointsProcessor(string fileName)
        {
            FileName = fileName;
        }

        public Point[] ReadPointSetFromFile()
        {
            var pointsFromFile = File.ReadAllLines(FileName);
            Point[] points = new Point[pointsFromFile.Length];

            for (int i = 0; i < pointsFromFile.Length; i++)
            {
                string currentLine = pointsFromFile[i];
                Point point = CreatePointFromFileLine(currentLine);
                points[i] = point;
            }
            return points;
        }
        
        public Point CreatePointFromFileLine(string line)
        {
            char[] charsToTrim = { '(', ')' };

            string lineClean = line.Trim(charsToTrim);

            string[] splitLine = lineClean.Split(',');

            double x = double.Parse(splitLine[0]);
            double y = double.Parse(splitLine[1]);

            Point newPoint = new Point(x, y);

            return newPoint;
        }
        
        public void WritePointToFile(Point pointNew)
        {
            var X = pointNew.Xvalue;
            var Y = pointNew.Yvalue;

            string pointInfo = '(' + X + "," + Y + ')';

            string[] pointArr = new string[] { pointInfo };
            File.AppendAllLines(FileName, pointArr);
        }

        public void WritePointToFile(Point[] pointSet)
        {
            string[] pointArr = new string[pointSet.Length];

            for (int i = 0; i < pointSet.Length; i++)
            {
                var X = pointSet[i].Xvalue;
                var Y = pointSet[i].Yvalue;

                string pointInfo = '(' + X + "," + Y + ')';

                pointArr[i] = pointInfo;
            }
            File.AppendAllLines(FileName, pointArr);
        }
    }
}
