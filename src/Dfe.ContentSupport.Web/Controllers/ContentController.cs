using System.Diagnostics;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Services;
using Dfe.ContentSupport.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers;

[Route("/content")]
[AllowAnonymous]
public class ContentController(IContentService contentService)
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

    [HttpGet("{slug}")]
    public async Task<IActionResult> Index(string slug, bool isPreview = false)
    {
        if (!ModelState.IsValid) return RedirectToAction("error");
        if (string.IsNullOrEmpty(slug)) return RedirectToAction("error");

        var resp = await contentService.GetContent(slug, isPreview);
        if (resp is null) return RedirectToAction("error");
        return View("CsIndex", resp);
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