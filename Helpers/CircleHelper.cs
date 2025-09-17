using System.Text.RegularExpressions;
using NCAP.Exceptions;

namespace NCAP.Helpers;

public class CircleHelper
{
    public static ICollection<Circle> ParseCircles(ICollection<string>? values)
    {
        if (values == null)
            return new List<Circle>();

        var circles = new List<Circle>();

        foreach (var value in values)
        {
            var parts = Regex.Split(value, "\\s+");

            //Check for a center point and radius
            if (parts.Length != 2)
                throw new InvalidCircleException();

            try
            {
                var centerParts = parts[0].Split(',');

                if (centerParts.Length != 2)
                    throw new InvalidCircleException();

                var center = new CoordinatePoint
                {
                    X = double.Parse(centerParts[0]),
                    Y = double.Parse(centerParts[1])
                };

                circles.Add(new Circle
                {
                    Center = center,
                    Radius = double.Parse(parts[1])
                });
            }
            catch (Exception)
            {
                //Invalid values found, unable to parse circle
                throw new InvalidCircleException();
            }
        }

        return circles;
    }

    public static ICollection<string> CirclesToStringCollection(ICollection<Circle> circles)
    {
        if (circles.Count == 0)
            return new List<string>();

        var formattedCircles = new List<string>();

        foreach (var circle in circles)
            formattedCircles.Add($"{circle.Center.X},{circle.Center.Y} {circle.Radius}");

        return formattedCircles;
    }
}