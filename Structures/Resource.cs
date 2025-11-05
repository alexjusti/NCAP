using System.Xml.Serialization;

namespace NCAP.Structures;

[XmlRoot("resource")]
public class Resource
{
    [XmlElement("resourceDesc")]
    public required string Description { get; set; }

    [XmlElement("mimeType")]
    public required string MimeType { get; set; }

    [XmlElement("size")]
    public int? Size { get; set; }

    [XmlElement("uri")]
    public string? Uri { get; set; }

    [XmlElement("derefUri")]
    public string? DerefUri { get; set; }

    [XmlElement("digest")]
    public string? Digest { get; set; }
}