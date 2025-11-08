using System.Xml.Serialization;

namespace NetCAP.Structures;

[XmlRoot("geocode")]
public class Geocode
{
    [XmlElement("valueName")]
    public string ValueName { get; set; }

    [XmlElement("value")]
    public string Value { get; set; }
}