using System.Diagnostics.CodeAnalysis;
using Azure.Identity;
using Contentful.AspNetCore;
using Dfe.ContentSupport.Web.Extensions;
using GovUk.Frontend.AspNetCore;


namespace Dfe.ContentSupport.Web;

[ExcludeFromCodeCoverage]
internal static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var keyVaultUri = $"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/";
        var azureCredentials = new DefaultAzureCredential();
        builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), azureCredentials);


        builder.Services.AddControllersWithViews();
        builder.Services.AddApplicationInsightsTelemetry();

        builder.Services.AddGovUkFrontend();
        builder.Services.AddContentful(builder.Configuration);
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

        app.MapControllerRoute(
            "sitemap",
            "sitemap.xml",
            new { controller = "Sitemap", action = "Index" }
        );

        app.MapControllerRoute(
            "default/{slug}",
            "{slug?}",
            new { controller = "Home", action = "Index" }
        );

        app.Run();
    }
}
