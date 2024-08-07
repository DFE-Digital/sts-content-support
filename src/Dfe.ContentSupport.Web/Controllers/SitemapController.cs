﻿using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Controllers;

[Route("/sitemap")]
[AllowAnonymous]
public class SitemapController(IContentService contentfulService) : Controller
{
    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
        var defaultModel = new CsPage
        {
            Heading = new Models.Heading
            {
                Title = "Department for Education",
                Subtitle = "Content and Support"
            }
        };


        return View(defaultModel);
    }

    [HttpGet]
    [Route("/sitemap.xml")]
    public async Task<IActionResult> Sitemap()
    {
        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/";
        var sitemap = await contentfulService.GenerateSitemap(baseUrl);
        return Content(sitemap, "application/xml");
    }
}