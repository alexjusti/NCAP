using System.Xml.Serialization;

namespace NCAP;

[XmlRoot("area")]
public class Geocode
{
    [XmlElement("valueName")]
    public string ValueName { get; set; }

    [XmlElement("value")]
    public string Value { get; set; }
}