using System.Diagnostics;
using Dfe.ContentSupport.Web.Services;
using Dfe.ContentSupport.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers;

public class HomeController(IContentService contentService)
    : Controller
{
    public async Task<IActionResult> Index(string slug, bool isPreview = false)
    {
        if (string.IsNullOrEmpty(slug)) return RedirectToAction("error");

        var resp = await contentService.GetContent(slug, isPreview);
        if (resp is null) return RedirectToAction("error");
        return View(resp);
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