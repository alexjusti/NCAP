using System.Xml.Serialization;
using NCAP.Helpers;

namespace NCAP.Structures;

[XmlRoot("info")]
public class Area
{
    [XmlElement("areaDesc")]
    public required string Description { get; set; }

    [XmlArray("area", IsNullable = false)]
    [XmlArrayItem("polygon", IsNullable = false)]
    private List<string>? _Polygons;

    [XmlIgnore]
    public List<Polygon> Polygons
    {
        get => PolygonHelper.ParsePolygons(_Polygons);

        set => _Polygons = PolygonHelper.PolygonsToStringCollection(value);
    }

    [XmlArray("area", IsNullable = false)]
    [XmlArrayItem("circle", IsNullable = false)]
    private List<string>? _Circles { get; set; }

    [XmlIgnore]
    public List<Circle> Circles
    {
        get => CircleHelper.ParseCircles(_Circles);

        set => _Circles = CircleHelper.CirclesToStringCollection(value);
    }

    [XmlArray("area", IsNullable = false)]
    [XmlArrayItem("geocode", IsNullable = false)]
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