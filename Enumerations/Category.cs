using System.ComponentModel;

namespace NetCAP.Enumerations;

public enum Category
{
    [Description("Geophysical")]
    Geo,

    [Description("Meteorological")]
    Met,

    [Description("Safety")]
    Safety,

    [Description]
    Security,

    [Description("Rescue")]
    Rescue,

    [Description("Fire")]
    Fire,

    [Description("Health")]
    Health,

    [Description("Environmental")]
    Env,

    [Description("Transport")]
    Transport,

    [Description("Infrastructure")]
    Infra,

    [Description("CBRNE")]
    CBRNE,

    [Description("Other")]
    Other
}