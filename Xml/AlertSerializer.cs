using System.Text;
using System.Xml.Serialization;

namespace NCAP.Xml;

public class AlertSerializer
{
    private string SerializeAlert(Alert alert)
    {
        var serializer = new XmlSerializer(typeof(Alert));

        using var writer = new Utf8StringWriter();
        serializer.Serialize(writer, alert);

        return writer.ToString();
    }
}

internal class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}