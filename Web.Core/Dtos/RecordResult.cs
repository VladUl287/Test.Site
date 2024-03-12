using Web.Core.Entities;

namespace Web.Core.Dtos;

public sealed class RecordResult
{
    public required Record[] Records { get; init; }

    public required int Count { get; init; }
}
