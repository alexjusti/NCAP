using System.Text;
using System.Xml.Serialization;
using NCAP.Exceptions;

namespace NCAP.Xml;

public class AlertDeserializer
{
    public static Alert DeserializeAlert(Stream stream)
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

    public static Alert DeserializeAlert(string xmlAlert)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream, Encoding.UTF8);

        writer.Write(xmlAlert);
        writer.Flush();
        stream.Position = 0;

        return DeserializeAlert(stream);
    }
}