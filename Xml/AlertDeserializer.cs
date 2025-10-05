using System.Text;
using System.Xml.Serialization;
using NCAP.Exceptions;
using NCAP.Structures;

namespace NCAP.Xml;

public class AlertDeserializer
{
    public static Alert? DeserializeAlert(Stream stream)
    {
        //An empty stream cannot be deserialized
        if (stream.Length == 0)
            throw new AlertDeserializationException();

        try
        {
            var serializer = new XmlSerializer(typeof(Alert));

            return (Alert)serializer.Deserialize(stream)!;
        }
        catch (Exception ex)
        {
            throw new AlertDeserializationException();
        }
    }

    public static IEnumerable<Alert>? DeserializeAlerts(Stream stream)
    {
        if (stream.Length == 0)
            throw new AlertDeserializationException();

        try
        {
            var serializer = new XmlSerializer(
                typeof(List<Alert>),
                new XmlRootAttribute("alerts"));

            return serializer.Deserialize(stream) as List<Alert>;
        }
        catch (Exception ex)
        {
            throw new AlertDeserializationException();
        }
    }

    public static Alert? DeserializeAlert(string xml)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, Encoding.UTF8);

        writer.Write(xml);
        writer.Flush();
        stream.Position = 0;

        return DeserializeAlert(stream);
    }

    public static IEnumerable<Alert>? DeserializeAlerts(string xml)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, Encoding.UTF8);

        writer.Write(xml);
        writer.Flush();
        stream.Position = 0;

        return DeserializeAlerts(stream);
    }
}