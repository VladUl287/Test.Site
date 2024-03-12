using Web.Core;
using Web.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Web.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class RecordController : ControllerBase
{
    private readonly IRecordPresenter recordPresenter;
    private readonly IMemoryCache memoryCache;

    public RecordController(IRecordPresenter recordPresenter, IMemoryCache memoryCache)
    {
        this.recordPresenter = recordPresenter;
        this.memoryCache = memoryCache;
    }

    [HttpGet]
    [ResponseCache(Duration = 30)]
    public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter)
    {
        var key = pageFilter.ToString();

        if (!memoryCache.TryGetValue(key, out RecordResult? result))
        {
            result = await recordPresenter.GetAll(pageFilter);

            if (result is not null)
            {
                memoryCache.Set(key, result, TimeSpan.FromMinutes(1));
            }
        }

        return Ok(result);
    }
}
