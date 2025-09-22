using System.Text.RegularExpressions;

namespace NCAP.Validators;

public class InputValidator
{
    /// <summary>
    /// Check the string for characters not allowed per the CAP protocol
    /// for specific fields
    /// </summary>
    /// <param name="identifier"></param>
    /// <returns></returns>
    public static bool ValidateCapInput(string identifier)
        => !Regex.IsMatch(identifier, @"[\\s,&<]");
}