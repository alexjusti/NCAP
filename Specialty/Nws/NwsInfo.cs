namespace NCAP.Specialty.Nws;

public class NwsInfo : Info
{
    /* See https://vlab.noaa.gov/web/nws-common-alerting-protocol/cap-documentation
     for additional details on the below properties in alerts issued by the NWS */

    public string? AWIPSIdentifier => FindParameterValue("AWIPSidentifier");

    public string? WMOIdentifier => FindParameterValue("WMOidentifier");

    public List<string>? NWSHeadlines => FindParameterValues("NWSheadline");

    public string? EventMotionDescription => FindParameterValue("eventMotionDescription");

    public string? WindThreat => FindParameterValue("windThreat");

    public string? MaxWindGust => FindParameterValue("maxWindGust");

    public string? HailThreat => FindParameterValue("hailThreat");

    public string? MaxHailSize => FindParameterValue("maxHailSize");

    public string? ThunderstormDamageThreat => FindParameterValue("thunderstormDamageThreat");

    public string? TornadoDetection => FindParameterValue("tornadoDetection");

    public string? TornadoDamageThreat => FindParameterValue("tornadoDamageThreat");

    public string? FlashFloodDetection => FindParameterValue("flashFloodDetection");

    public string? FlashFloodDamageThreat => FindParameterValue("flashFloodDamageThreat");

    public string? SnowSquallDetection => FindParameterValue("snowSquallDetection");

    public string? SnowSquallImpact =>  FindParameterValue("snowSquallImpact");

    public string? WaterspoutDetection => FindParameterValue("waterspoutDetection");

    public List<BlockChannel>? BlockChannels
    {
        get
        {
            return FindParameterValues("BLOCKCHANNEL")?
                .Select(Enum.Parse<BlockChannel>)
                .ToList();
        }
    }

    public string? EASOrigin => FindParameterValue("EAS-ORG");

    public string? ValidTimeEventCode => FindParameterValue("VTEC");

    public DateTime? EventEndingTime
    {
        get
        {
            var value = FindParameterValue("eventEndingTime");
            return value == null ? null : DateTime.Parse(value);
        }
    }

    public bool? WEAHandling
    {
        get
        {
            var value = FindParameterValue("WEAhandling");

            return value == null ? null : value == "Imminent Threat";
        }
    }

    public string? CMAMText => FindParameterValue("CMAMtext");

    public string? CMAMLongText => FindParameterValue("CMAMlongtext");

    public List<string>? ExpiredReferences
    {
        get
        {
            return FindParameterValue("expiredReferences")
                ?.Split()
                .ToList();
        }
    }
}