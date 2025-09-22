using System.Xml.Serialization;

namespace NCAP;

[XmlRoot(elementName: "parameter")]
public class Parameter
{
    [XmlElement("valueName")]
    public string ValueName { get; set; }

    [XmlElement("value")]
    public string Value { get; set; }
}