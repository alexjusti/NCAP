namespace NetCAP.Exceptions;

public class InvalidCircleException : Exception;

public class InvalidPolygonException : Exception;

public class RestrictedCharacterException : Exception;

public class AlertSerializationException : Exception
{
    public override string Message => "An error occurred while attempting to serialize an alert.";
}

public class AlertDeserializationException : Exception
{
    public override string Message => "An error occurred while attempting to deserialize an alert.";
}