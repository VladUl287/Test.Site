namespace Web.Api.Configuration;

public sealed class Cors
{
    public const string Position = "Cors";

    public required string[] Origins { get; init; }
}
