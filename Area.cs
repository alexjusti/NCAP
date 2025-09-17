using NCAP.Helpers;

namespace NCAP;

public class Area
{
    public string Description { get; set; }

    private ICollection<string>? _Polygons;

    public ICollection<Polygon> Polygons
    {
        get => PolygonHelper.ParsePolygons(_Polygons);

        set => _Polygons = PolygonHelper.PolygonsToStringCollection(value);
    }

    private ICollection<string>? _Circles { get; set; }

    public ICollection<Circle> Circles
    {
        get => CircleHelper.ParseCircles(_Circles);

        set => _Circles = CircleHelper.CirclesToStringCollection(value);
    }

    private ICollection<Geocode>? _Geocodes { get; set; }

    public ICollection<Geocode>? Geocodes => _Geocodes ?? new List<Geocode>();

    public int? Altitude { get; set; }

    public int? Ceiling { get; set; }
}