using System.ComponentModel;

namespace NCAP.Enumerations;

public enum ResponseType
{
    [Description("Shelter")]
    Shelter,

    [Description("Evacuate")]
    Evacuate,

    [Description("Prepare")]
    Prepare,

    [Description("Execute")]
    Execute,

    [Description("Avoid")]
    Avoid,

    [Description("Monitor")]
    Monitor,

    [Description("Assess")]
    Assess,

    [Description("All Clear")]
    AllClear,

    [Description("None")]
    None
}