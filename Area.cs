using System.Text.RegularExpressions;
using NCAP.Exceptions;
using NCAP.Helpers;

namespace NCAP;

public class Area
{
    public string Description { get; set; }

    private ICollection<string> _polygons;

    public ICollection<Polygon> Polygons
    {
        get => PolygonHelper.ParsePolygons(_polygons);

        set => _polygons = PolygonHelper.PolygonsToStringCollection(value);
    }

    public ICollection<>
}