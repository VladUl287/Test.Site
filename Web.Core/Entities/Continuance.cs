using Newtonsoft.Json;

namespace Web.Core.Entities;

public sealed class Continuance
{
    [JsonProperty("agents_chatting_duration")]
    public int AgentsChattingDuration { get; init; }
    public int Duration { get; init; }
    public int Count { get; init; }
}
