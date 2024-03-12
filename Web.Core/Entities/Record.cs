namespace Web.Core.Entities;

public sealed class Record
{
    public required string Date { get; set; }
    public required int Total { get; init; }
    public required Continuance Duration { get; init; } = new();
    public required Rating Rating { get; init; } = new();
    public required Response Response { get; init; } = new();
    public required Dictionary<string, int> Tags { get; init; } = [];
}
