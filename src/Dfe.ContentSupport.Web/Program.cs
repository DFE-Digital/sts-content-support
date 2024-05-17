using System.Diagnostics.CodeAnalysis;
using Contentful.AspNetCore;
using Dfe.ContentSupport.Web.Extensions;
using GovUk.Frontend.AspNetCore;

[ExcludeFromCodeCoverage]
internal static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddContentful(builder.Configuration);
        builder.Services.AddGovUkFrontend();
        builder.InitDependencyInjection();

        var app = builder.Build();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute("sitemap",
            "sitemap.xml",
            new { controller = "Sitemap", action = "Index" }
        );

        app.MapControllerRoute(
            "mockContent",
            "Home/MockContent",
            new { controller = "Home", action = "MockContent" }
        );

        app.MapControllerRoute(
            "default/{slug}",
            "{slug?}",
            new { controller = "Home", action = "Index" }
        );

        app.Run();
    }
}
