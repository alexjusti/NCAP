using NCAP.Enumerations;

namespace NCAP;

public class Info
{
    public string? Language { get; set; }

    public ICollection<Category> Categories { get; set; }

    public string Event { get; set; }

    public ResponseType? ResponseType { get; set; }

    public Urgency Urgency { get; set; }

    public Severity Severity { get; set; }

    public Certainty Certainty { get; set; }

    public string? Audience { get; set; }

    public ICollection<EventCode> EventCodes { get; set; }

    public DateTime? Effective { get; set; }

    public DateTime? Onset { get; set; }

    public DateTime? Expires { get; set; }

    public string? SenderName { get; set; }

    public string? Headline { get; set; }

    public string? Description { get; set; }

    public string? Instruction { get; set; }

    public string? Web { get; set; }

    public string? Contact { get; set; }

    public ICollection<Parameter> Parameters { get; set }
}