using System.Diagnostics;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Services;
using Dfe.ContentSupport.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers;

[Route("/content")]
[AllowAnonymous]
public class ContentController(IContentService contentService, ILayoutService layoutService, ILogger<ContentController> logger)
    : Controller
{
    public async Task<IActionResult> Home()
    {
        var defaultModel = new CsPage
        {
            Heading = new Models.Heading
            {
                Title = "Department for Education",
                Subtitle = "Content and Support"
            }
        };

        ViewBag.pages = await contentService.GetCsPages();

        return View(defaultModel);
    }

    [HttpGet("{slug}/{page?}")]
    public async Task<IActionResult> Index(string slug, string page = "", bool isPreview = false, [FromQuery] List<string>? tags = null)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("Invalid model state received for {Slug}", slug);
            return RedirectToAction("error");
        }

        if (string.IsNullOrEmpty(slug))
        {
            logger.LogError("No slug received for C&S {Controller} {Action} ", nameof(ContentController), nameof(Index));
            return RedirectToAction("error");
        }

        try
        {
            var resp = await contentService.GetContent(slug, isPreview);
            if (resp is null)
            {
                logger.LogError("Failed to load content for C&S page {Slug}; no content received.", slug);
                return RedirectToAction("error");
            }

            resp = layoutService.GenerateLayout(resp, Request, page);
            ViewBag.tags = tags;

            return View("CsIndex", resp);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error loading C&S content page {Slug}", slug);
            return RedirectToAction("error");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}