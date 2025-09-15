namespace NCAP;

public struct PolygonPoint
{
    public double X;

    public double Y;
}

public class Polygon
{
    public ICollection<PolygonPoint> Points { get; set; }
}