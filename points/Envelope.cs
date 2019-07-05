namespace points
{
    public class Envelope
    {
        public double Xmax { get; }
        public double Xmin { get; }
        public double Ymax { get; }
        public double Ymin { get; }

        public Envelope(double xmax, double xmin, double ymax, double ymin)
        {
            Xmax = xmax;
            Xmin = xmin;
            Ymax = ymax;
            Ymin = ymin;
        }

    }
}