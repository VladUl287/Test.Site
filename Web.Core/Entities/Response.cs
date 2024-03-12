using Newtonsoft.Json;

namespace Web.Core.Entities;

public sealed class Response
{
    [JsonProperty("response_time")]
    public float ResponseTime { get; init; }
    public int Count { get; init; }
}
