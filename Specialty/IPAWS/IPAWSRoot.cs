using System.Xml.Serialization;
using NetCAP.Structures;

namespace NetCAP.Specialty.IPAWS;

[XmlRoot("alerts", Namespace = "http://gov.fema.ipaws.services/feed")]
public class IPAWSRoot
{
    [XmlElement("alert", Namespace = "urn:oasis:names:tc:emergency:cap:1.2")]
    public List<Alert> Alerts { get; set; }
}