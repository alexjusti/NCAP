using NetCAP.Structures;
using System.Xml.Linq;
using NetCAP.Enumerations;

namespace NetCAP.Specialty.Nws;

/* Since the National Weather Service can't play nice in the sandbox and format their
 alerts like everyone else, we have to map their alerts to the standard CAP 1.2 format */
public class NWSAlertMapper
{
    private static string GetElementValue(IEnumerable<XElement> elements, string name) =>
        elements.FirstOrDefault(e => e.Name == name)?.Value!;

    private static IEnumerable<string> GetElementValues(IEnumerable<XElement> elements, string name)
        => elements.Where(e => e.Name == name)?
            .Select(e => e.Value)!;

    private static Area MapArea(IEnumerable<XElement> elements)
    {
        //Map all geocode elements
        var geocodes = elements.Where(e => e.Name == "geocode")
            .Select(e => e.Descendants())
            .Select(g => new Geocode
            {
                ValueName = GetElementValue(g, "valueName"),
                Value = GetElementValue(g, "value")
            }).ToList();

        return new Area
        {
            Description = GetElementValue(elements, "areaDesc"),
            _Polygons = [.. GetElementValues(elements, "polygon")],
            Geocodes = geocodes
        };
    }

    private static IEnumerable<EventCode> MapEventCodes(IEnumerable<XElement> elements)
    {
        return elements.Where(e => e.Name == "eventCode")
            .Select(e => e.Descendants())
            .Select(ec => new EventCode
            {
                ValueName = GetElementValue(ec, "valueName"),
                Value = GetElementValue(ec, "value")
            });
    }

    private static IEnumerable<Parameter> MapParameters(IEnumerable<XElement> elements)
    {
        return elements.Where(e => e.Name == "parameter")
            .Select(e => e.Descendants())
            .Select(p => new Parameter
            {
                ValueName = GetElementValue(p, "valueName"),
                Value = GetElementValue(p, "value")
            });
    }

    public static IEnumerable<Alert> MapAlertsFromFeed(Stream stream)
    {
        var entries = XDocument.Load(stream)
            .Element("feed")
            ?.Elements("entry")
            .ToList();

        var alerts = new List<Alert>();

        foreach (var entry in entries)
        {
            var descendants = entry.Descendants()
                .AsQueryable();

            var alert = new Alert
            {
                //Alert properties
                Identifier = GetElementValue(descendants, "identifier"),
                Sender = GetElementValue(descendants, "sender"),
                Sent = DateTime.Parse(GetElementValue(descendants, "sent")),
                Status = Enum.Parse<Status>(GetElementValue(descendants, "status")),
                MessageType = Enum.Parse<MessageType>(GetElementValue(descendants, "msgType")),
                Scope = Enum.Parse<Scope>(GetElementValue(descendants, "scope")),
                Codes = [.. GetElementValues(descendants, "code")],
                Note = GetElementValue(descendants, "note"),
                _References = GetElementValue(descendants, "references"),

                //Info Properties
                Info =
                [
                    new Info
                    {
                        Language = GetElementValue(descendants, "language"),
                        Categories = [.. GetElementValues(descendants, "category").Select(Enum.Parse<Category>)],
                        Event = GetElementValue(descendants, "event"),
                        ResponseType = Enum.Parse<ResponseType>(GetElementValue(descendants, "responseType")),
                        Urgency = Enum.Parse<Urgency>(GetElementValue(descendants, "urgency")),
                        Severity = Enum.Parse<Severity>(GetElementValue(descendants, "severity")),
                        Certainty = Enum.Parse<Certainty>(GetElementValue(descendants, "certainty")),
                        Audience = GetElementValue(descendants, "audience"),
                        EventCodes = [..MapEventCodes(descendants)],
                        Effective = DateTime.Parse(GetElementValue(descendants, "effective")),
                        Onset = DateTime.Parse(GetElementValue(descendants, "onset")),
                        Expires = DateTime.Parse(GetElementValue(descendants, "expires")),
                        SenderName = GetElementValue(descendants, "senderName"),
                        Headline = GetElementValue(descendants, "headline"),
                        Description = GetElementValue(descendants, "description"),
                        Instruction = GetElementValue(descendants, "instruction"),
                        Web = GetElementValue(descendants, "web"),
                        Areas = [MapArea(descendants)],
                        Parameters = [..MapParameters(descendants)]
                    }
                ]
            };

            alerts.Add(alert);
        }

        return alerts;
    }
}