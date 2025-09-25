using NCAP.Exceptions;
using System.Text.RegularExpressions;

namespace NCAP.Helpers;

public static class PolygonHelper
{
    /// <summary>
    /// Parse polygons formatted as strings into a collection of Polygon objects
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <exception cref="InvalidPolygonException"></exception>
    public static List<Polygon> ParsePolygons(List<string>? values)
    {
        if (values == null)
            return new List<Polygon>();

        var polygons = new List<Polygon>();

        foreach (var polygon in values)
        {
            var pointPairs = Regex.Split(polygon, "\\s+");

            //Check for a valid number of points ( >= 4)
            if (pointPairs.Length < 4)
                throw new InvalidPolygonException();

            //Check to ensure that two identical points are present
            if (pointPairs.Length == pointPairs.Distinct().Count())
                throw new InvalidPolygonException();

            var points = new List<CoordinatePoint>();

            foreach (var pair in pointPairs)
            {
                var parts = pair.Split(',');

                if (parts.Length < 2)
                    throw new InvalidPolygonException();

                try
                {
                    points.Add(new CoordinatePoint
                    {
                        X = double.Parse(parts[0]),
                        Y = double.Parse(parts[1])
                    });
                }
                catch (Exception)
                {
                    //Invalid latitude/longitude point found, unable to parse polygon
                    throw new InvalidPolygonException();
                }
            }

            polygons.Add(new Polygon
            {
                Points = points
            });
        }

        return polygons;
    }

    /// <summary>
    /// Convert a collection of Polygon objects into formatted strings
    /// </summary>
    /// <param name="polygons"></param>
    /// <returns></returns>
    public static List<string> PolygonsToStringCollection(List<Polygon> polygons)
    {
        if (polygons.Count == 0)
            return new List<string>();

        var formattedPolygons = new List<string>(polygons.Count);

        foreach (var polygon in polygons)
        {
            var points = new List<string>();

            foreach (var point in polygon.Points)
                points.Add($"{point.X},{point.Y}");

            formattedPolygons.Add(string.Join(' ', points));
        }

        return formattedPolygons;
;    }
}