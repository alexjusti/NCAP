using System.Text.RegularExpressions;
using System.Xml.Serialization;
using NCAP.Enumerations;

namespace NCAP.Structures;

[XmlRoot("alert", Namespace = "urn:oasis:names:tc:emergency:cap:1.2")]
public class Alert
{
    [XmlElement("identifier")]
    public required string Identifier { get; set; }

    [XmlElement("sender")]
    public required string Sender { get; set; }

    [XmlElement("sent", IsNullable = false)]
    #pragma warning disable CS8618
    private string _Sent { get; set; }
    #pragma warning restore CS8618

    [XmlIgnore]
    public required DateTime Sent
    {
        get => DateTime.Parse(_Sent);
        set => _Sent = value.ToString("s");
    }

    [XmlElement("status", IsNullable = false)]
    public required Status Status { get; set; }

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
    public List<string> Addresses
    {
        get
        {
            if (_Addresses == null)
                return [];

            var addresses = _Addresses.Split().ToList();

            addresses.ForEach(item => { item.Trim('"'); });

            return addresses;
        }

        set
        {
            var addresses = new List<string>();

            foreach (var address in value)
            {
                //Check string for whitespace & surround with quotes if whitespace is present
                if (Regex.Match(address, @"\s").Length > 0)
                    addresses.Add($"\"{address}\"");
                else
                    addresses.Add(address);
            }

            _Addresses = string.Join(' ', addresses);
        }
    }

    [XmlElement("code")]
    public List<string>? Codes { get; set; }

    [XmlElement("note", IsNullable = false)]
    public string? Note { get; set; }

    [XmlElement("references", IsNullable = false)]
    private string? _References { get; set; }

    [XmlIgnore]
    public List<string> References
    {
        get
        {
            if (_References == null)
                return [];

            return _References
                .Split()
                .ToList();
        }
    }

    [XmlElement("info")]
    public required List<Info> Info { get; set; }
}