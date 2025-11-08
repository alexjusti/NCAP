using System.Xml.Serialization;
using NetCAP.Helpers;

namespace NetCAP.Structures;

[XmlRoot("area")]
public class Area
{
    [XmlElement("areaDesc")]
    public required string Description { get; set; }

    [XmlElement("polygon")]
    public List<string>? _Polygons;

    [XmlIgnore]
    public List<Polygon> Polygons
    {
        get => PolygonHelper.ParsePolygons(_Polygons);

        set => _Polygons = PolygonHelper.PolygonsToStringCollection(value);
    }

    [XmlElement("circle")]
    public List<string>? _Circles { get; set; }

    [XmlIgnore]
    public List<Circle> Circles
    {
        get => CircleHelper.ParseCircles(_Circles);

        set => _Circles = CircleHelper.CirclesToStringCollection(value);
    }

    [XmlElement("geocode")]
    public List<Geocode>? Geocodes { get; set; }

    [XmlIgnore]
    public List<string>? SameCodes =>
        Geocodes?.Where(geocode => geocode.ValueName == "SAME")
            .Select(geocode => geocode.Value)
            .ToList();

    [XmlElement("altitude")]
    public int? Altitude { get; set; }

    [XmlElement("ceiling")]
    public int? Ceiling { get; set; }
}