using Web.Core.Dtos;

namespace Web.Infrastructure.Extensions;

internal static class Collections
{
    public static IEnumerable<T> PageFilter<T>(this IEnumerable<T> data, PageFilter? pageFilter)
    {
        var result = data.AsEnumerable();

        if (pageFilter is not null)
        {
            var skip = (pageFilter.Page - 1) * pageFilter.Size;
            var take = pageFilter.Size;
            result = result.Skip(skip).Take(take);
        }

        return result;
    }
}
