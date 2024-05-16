using System.Diagnostics;
using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dfe.ContentSupport.Web.Controllers;

public class HomeController(IContentfulService contentfulService) : Controller
{
    public async Task<IActionResult> Index(string slug)
    {
        if (string.IsNullOrEmpty(slug)) return RedirectToAction("error");
        var resp = await contentfulService.GetContent(slug) as ContentSupportPage;

        return View(resp);
    }

    public IActionResult MockContent(string slug)
    {
        var json = System.IO.File.ReadAllText("MockData/mockContent.json");
        var resp = JsonConvert.DeserializeObject<ContentSupportPage>(json);
        return View("Index", resp);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
