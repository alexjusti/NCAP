namespace NCAP;

public class Resource
{
    public string Description { get; set; }

    public string MimeType { get; set; }

    public int? Size { get; set; }

    public string? Uri { get; set; }

    public string? DerefUri { get; set; }

    public string? Digest { get; set; }
}