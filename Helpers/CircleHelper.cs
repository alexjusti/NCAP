using System.Text.RegularExpressions;
using NCAP.Exceptions;

namespace NCAP.Helpers;

public class CircleHelper
{
    /// <summary>
    /// Parse circles formatted as strings into a collection of Circle Objects
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <exception cref="InvalidCircleException"></exception>
    public static List<Circle> ParseCircles(List<string>? values)
    {
        if (values == null)
            return [];

        var circles = new List<Circle>();

        foreach (var parts in values.Select(value => Regex.Split(value, "\\s+")))
        {
            //Check for a center point and radius
            if (parts.Length != 2)
                throw new InvalidCircleException();

            try
            {
                var centerParts = parts[0].Split(',');

                //Check for a valid center point
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

    /// <summary>
    /// Convert a collection of circle objects into formatted strings
    /// </summary>
    /// <param name="circles"></param>
    /// <returns></returns>
    public static List<string> CirclesToStringCollection(List<Circle> circles)
    {
        if (circles.Count == 0)
            return [];

        return circles
            .Select(circle => $"{circle.Center.X},{circle.Center.Y} {circle.Radius}")
            .ToList();
    }
}