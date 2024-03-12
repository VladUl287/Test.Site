using Web.Core;
using Web.Core.Entities;
using Web.Core.Dtos;
using Web.Infrastructure.Extensions;
using Web.Infrastructure.Helpers;
using Microsoft.Extensions.Logging;

namespace Web.Infrastructure;

public sealed class RecordPresenter : IRecordPresenter
{
    private readonly ILogger<RecordPresenter> logger;

    private static readonly string Path = AppDomain.CurrentDomain.BaseDirectory + "/Data/";

    public RecordPresenter(ILogger<RecordPresenter> logger)
    {
        this.logger = logger;
    }

    public async Task<RecordResult> GetAll(PageFilter? pageFilter)
    {
        const string Records = "records";

        var jsonTotal = await File.ReadAllTextAsync(Path + "totalChats.json");
        var data = Json.GetFirstInstance<Dictionary<string, Record>>(Records, jsonTotal) ?? [];

        var jsonFiles = new (string, Func<Record, object>)[]
        {
                ("tags.json", (record) => record.Tags),
                ("ratings.json", (record) => record.Rating),
                ("duration.json", (record) => record.Duration),
                ("responseTime.json", (record) => record.Response),
        };

        foreach (var (fileName, populateAction) in jsonFiles)
        {
            var jsonContent = await File.ReadAllTextAsync(Path + fileName);
            Json.PopulateInstance(jsonContent, data, populateAction);
        }

        var records = data
            .OrderBy(record => DateTime.Parse(record.Key))
            .PageFilter(pageFilter)
            .Select(record =>
            {
                record.Value.Date = record.Key;
                return record.Value;
            })
            .ToArray();

        return new RecordResult
        {
            Records = records,
            Count = data.Count
        };
    }
}
