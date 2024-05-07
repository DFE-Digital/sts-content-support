using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dfe.ContentSupport.Web.Models;

namespace Dfe.ContentSupport.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IContentfulService _contentfulService;

    public HomeController(ILogger<HomeController> logger, IContentfulService contentfulService)
    {
        _logger = logger;
        _contentfulService = contentfulService;
    }

    public async Task<IActionResult> Index()
    {
        var resp =  await _contentfulService.GetContent();
        return View(resp);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
