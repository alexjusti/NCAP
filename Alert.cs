using System.Xml.Serialization;
using NCAP.Enumerations;

namespace NCAP;

[XmlRoot("alert")]
public class Alert
{
    [XmlElement("identifier")]
    public required string Identifier { get; set; }

    [XmlElement("sender")]
    public required string Sender { get; set; }

    [XmlElement("sent", IsNullable = false)]
    private string _Sent { get; set; }

    [XmlIgnore]
    public required DateTime Sent
    {
        get => DateTime.Parse(_Sent);
        set => _Sent = value.ToString("s");
    }

    [XmlElement("status", IsNullable = false)]
    public Status Status { get; set; }

    [XmlElement("msgType")]
    public required MessageType MessageType { get; set; }

    [XmlElement("source", IsNullable = false)]
    public string? Source { get; set; }

    [XmlElement("scope")]
    public required Scope Scope { get; set; }

    [XmlElement("restriction", IsNullable = false)]
    public string? Restriction { get; set; }

    [XmlElement("addresses", IsNullable = false)]
    private string? _Addresses { get; set; }

    /// <summary>
    /// Parse the addresses element; addresses are separated by whitespace
    /// and contain double quotes for addresses containing whitespace
    /// </summary>
    [XmlIgnore]
    public ICollection<string> Addresses
    {
        get
        {
            if (_Addresses == null)
                return new List<string>();

            var addresses = _Addresses.Split(" ").ToList();

            addresses.ForEach(item => { item.Trim('"'); });

            return addresses;
        }

        set => _Addresses = string.Join(' ', value);
    }

    [XmlArray("alert", IsNullable = false)]
    [XmlArrayItem(elementName: "code", IsNullable = false)]
    public ICollection<string>? Codes { get; set; }

    [XmlElement("note", IsNullable = false)]
    public string? Note { get; set; }

    [XmlElement("references", IsNullable = false)]
    private string? _References { get; set; }

    /// <summary>
    /// Parse the references element; references are separated by whitespace
    /// </summary>
    [XmlIgnore]
    public ICollection<string> References
        => _References == null ? [] : _References.Split().ToList();
}