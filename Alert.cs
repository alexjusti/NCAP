using NCAP.Enumerations;

namespace NCAP;

public class Alert
{
    public string Identifier { get; set; }

    public string Sender { get; set; }

    public DateTime Sent { get; set; }

    public Status Status { get; set; }

    public MessageType MessageType { get; set; }

    public string? Source { get; set; }

    public Scope Scope { get; set; }

    public string? Restriction { get; set; }

    private string? _Addresses { get; set; }

    /// <summary>
    /// Parse the addresses element; addresses are separated by whitespace
    /// and contain double quotes for addresses containing whitespace
    /// </summary>
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
    }

    public ICollection<string> Codes { get; set; }

    public string? Note { get; set; }

    private string? _References { get; set; }

    /// <summary>
    /// Parse the references element; references are separated by whitespace
    /// </summary>
    public ICollection<string> References
        => _References == null ? [] : _References.Split(" ").ToList();
}