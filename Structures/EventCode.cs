using System.Xml.Serialization;

namespace NCAP.Structures;

[XmlRoot("info")]
public class EventCode
{
    [XmlElement("valueName")]
    public string ValueName { get; set; }

    [XmlElement("value")]
    public string Value { get; set; }
}