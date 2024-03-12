using Newtonsoft.Json;

namespace Web.Infrastructure.Helpers;

internal static class Json
{
    public static T? GetFirstInstance<T>(string propertyName, string json)
    {
        using var stringReader = new StringReader(json);
        using var jsonReader = new JsonTextReader(stringReader);

        while (jsonReader.Read())
        {
            if (jsonReader.TokenType == JsonToken.PropertyName && jsonReader.Value?.ToString() == propertyName)
            {
                jsonReader.Read();

                return new JsonSerializer()
                    .Deserialize<T>(jsonReader);
            }
        }

        return default;
    }

    public static void PopulateInstance<T, U>(string json, Dictionary<string, U> data, Func<U, T> getTarget)
    {
        using var stringReader = new StringReader(json);
        using var jsonReader = new JsonTextReader(stringReader);

        while (jsonReader.Read())
        {
            var property = jsonReader.Value?.ToString() ?? string.Empty;
            if (jsonReader.TokenType == JsonToken.PropertyName && data.TryGetValue(property, out var value))
            {
                jsonReader.Read();
                var destination = getTarget(value);
                if (destination is not null)
                {
                    new JsonSerializer()
                        .Populate(jsonReader, destination);
                }
            }
        }
    }
}
