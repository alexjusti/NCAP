using System.Xml.Serialization;
using NCAP.Helpers;

namespace NCAP;

[XmlRoot("area")]
public class Area
{
    [XmlElement("areaDesc")]
    public required string Description { get; set; }

    [XmlArray("area", IsNullable = false)]
    [XmlArrayItem("polygon", IsNullable = false)]
    private ICollection<string>? _Polygons;

    [XmlIgnore]
    public ICollection<Polygon> Polygons
    {
        get => PolygonHelper.ParsePolygons(_Polygons);

        set => _Polygons = PolygonHelper.PolygonsToStringCollection(value);
    }

    [XmlArray("area", IsNullable = false)]
    [XmlArrayItem("circle", IsNullable = false)]
    private ICollection<string>? _Circles { get; set; }

    [XmlIgnore]
    public ICollection<Circle> Circles
    {
        get => CircleHelper.ParseCircles(_Circles);

        set => _Circles = CircleHelper.CirclesToStringCollection(value);
    }

    [XmlArray("area", IsNullable = false)]
    [XmlArrayItem("geocode", IsNullable = false)]
    public ICollection<Geocode>? Geocodes { get; set; }

    [XmlElement("altitude", IsNullable = false)]
    public int? Altitude { get; set; }

    [XmlElement("ceiling", IsNullable = false)]
    public int? Ceiling { get; set; }
}