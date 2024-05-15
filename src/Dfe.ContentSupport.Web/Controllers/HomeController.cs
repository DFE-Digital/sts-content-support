using System.Diagnostics;
using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers;

public class HomeController(IContentService contentfulService)
    : Controller
{
    public async Task<IActionResult> Index(string slug)
    {
        if (string.IsNullOrEmpty(slug)) return RedirectToAction("error");

        var resp = await contentfulService.GetContent(slug);
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