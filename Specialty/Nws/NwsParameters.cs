namespace NCAP.Specialty.Nws;

public class NwsParameters(Info info)
{
    /* See https://vlab.noaa.gov/web/nws-common-alerting-protocol/cap-documentation
     for additional details on the below properties in alerts issued by the NWS */

    private Info Info { get; set; } = info;

    public string? AWIPSIdentifier => Info.FindParameterValue("AWIPSidentifier");

    public string? WMOIdentifier => Info.FindParameterValue("WMOidentifier");

    public List<string>? NWSHeadlines => Info.FindParameterValues("NWSheadline");

    public string? EventMotionDescription => Info.FindParameterValue("eventMotionDescription");

    public string? WindThreat => Info.FindParameterValue("windThreat");

    public string? MaxWindGust => Info.FindParameterValue("maxWindGust");

    public string? HailThreat => Info.FindParameterValue("hailThreat");

    public string? MaxHailSize => Info.FindParameterValue("maxHailSize");

    public string? ThunderstormDamageThreat => Info.FindParameterValue("thunderstormDamageThreat");

    public string? TornadoDetection => Info.FindParameterValue("tornadoDetection");

    public string? TornadoDamageThreat => Info.FindParameterValue("tornadoDamageThreat");

    public string? FlashFloodDetection => Info.FindParameterValue("flashFloodDetection");

    public string? FlashFloodDamageThreat => Info.FindParameterValue("flashFloodDamageThreat");

    public string? SnowSquallDetection => Info.FindParameterValue("snowSquallDetection");

    public string? SnowSquallImpact =>  Info.FindParameterValue("snowSquallImpact");

    public string? WaterspoutDetection => Info.FindParameterValue("waterspoutDetection");

    public List<BlockChannel>? BlockChannels =>
        Info.FindParameterValues("BLOCKCHANNEL")?
            .Select(Enum.Parse<BlockChannel>)
            .ToList();

    public string? EASOrigin => Info.FindParameterValue("EAS-ORG");

    public string? ValidTimeEventCode => Info.FindParameterValue("VTEC");

    public DateTime? EventEndingTime
    {
        get
        {
            var value = Info.FindParameterValue("eventEndingTime");
            return value == null ? null : DateTime.Parse(value);
        }
    }

    public bool? WEAHandling
    {
        get
        {
            var value = Info.FindParameterValue("WEAhandling");

            return value == null ? null : value == "Imminent Threat";
        }
    }

    public string? CMAMText => Info.FindParameterValue("CMAMtext");

    public string? CMAMLongText => Info.FindParameterValue("CMAMlongtext");

    public List<string>? ExpiredReferences =>
        Info.FindParameterValue("expiredReferences")
            ?.Split()
            .ToList();
}