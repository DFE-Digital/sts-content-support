using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers;

public class CacheController(ICacheService<List<CsPage>> cache) : Controller
{
    public void Clear()
    {
        cache.ClearCache();
    }
}