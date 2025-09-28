using System.Xml.Serialization;
using NCAP.Constants;
using NCAP.Enumerations;
using NCAP.Specialty.Nws;

namespace NCAP.Structures;

[XmlRoot("alert")]
public class Info
{
    [XmlElement("language", IsNullable = false)]
    public string? Language { get; set; }

    [XmlElement("category")]
    public required List<Category> Categories { get; set; }

    [XmlElement("event")]
    public required string Event { get; set; }

    [XmlElement("responseType")]
    public ResponseType? ResponseType { get; set; }

    public bool ShouldSerializeResponseType() => ResponseType.HasValue;

    [XmlElement("urgency")]
    public required Urgency Urgency { get; set; }

    [XmlElement("severity")]
    public required Severity Severity { get; set; }

    [XmlElement("certainty")]
    public required Certainty Certainty { get; set; }

    [XmlElement("audience", IsNullable = false)]
    public string? Audience { get; set; }

    [XmlElement("eventCode")]
    public List<EventCode>? EventCodes { get; set; }

    [XmlElement("effective", IsNullable = false)]
    public string? _Effective { get; set; }

    [XmlIgnore]
    public DateTime? Effective
    {
        get => _Effective == null ? null : DateTime.Parse(_Effective);

        set => _Effective = value?.ToString("s");
    }

    [XmlElement("onset", IsNullable = false)]
    public string? _Onset { get; set; }

    [XmlIgnore]
    public DateTime? Onset
    {
        get => _Onset == null ? null : DateTime.Parse(_Onset);

        set => _Onset = value?.ToString("s");
    }

    [XmlElement("expires", IsNullable = false)]
    #pragma warning disable CS8618
    public string _Expires { get; set; }
    #pragma warning restore CS8618

    [XmlIgnore]
    public required DateTime Expires
    {
        get => DateTime.Parse(_Expires);

        set => _Expires = value.ToString("s");
    }

    [XmlElement("senderName", IsNullable = false)]
    public string? SenderName { get; set; }

    [XmlElement("headline", IsNullable = false)]
    public string? Headline { get; set; }

    [XmlElement("description", IsNullable = false)]
    public string? Description { get; set; }

    [XmlElement("instruction", IsNullable = false)]
    public string? Instruction { get; set; }

    [XmlElement("web", IsNullable = false)]
    public string? Web { get; set; }

    [XmlElement("contact", IsNullable = false)]
    public string? Contact { get; set; }

    [XmlElement("parameter")]
    public List<Parameter>? Parameters { get; set; }

    public string? FindParameterValue(string parameterName)
    {
        return Parameters?
            .FirstOrDefault(p => p.ValueName == parameterName)?
            .Value;
    }

    public List<string>? FindParameterValues(string parameterName)
    {
        return Parameters?
            .Where(p => p.ValueName == parameterName)
            .Select(p => p.ValueName)
            .ToList();
    }

    [XmlIgnore]
    public NwsParameters? NwsParameters => SenderName == NwsConstants.WebmasterEmail
        ? new NwsParameters(this)
        : null;

    [XmlElement("resource")]
    public List<Resource>? Resources { get; set; }

    [XmlElement("area")]
    public List<Area>? Areas { get; set; }
}