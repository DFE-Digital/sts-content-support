using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IContentfulService _contentfulService;

        public SitemapController(IContentfulService contentfulService)
        {
            _contentfulService = contentfulService;
        }

        public async Task<IActionResult> Index()
        {
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
            var sitemap = await _contentfulService.GenerateSitemap(baseUrl);
            return Content(sitemap, "application/xml");
        }
    }
}
