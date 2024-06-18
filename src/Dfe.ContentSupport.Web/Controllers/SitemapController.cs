using Dfe.ContentSupport.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers;

public class SitemapController(IContentService contentfulService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
        var sitemap = await contentfulService.GenerateSitemap(baseUrl);
        return Content(sitemap, "application/xml");
    }
}