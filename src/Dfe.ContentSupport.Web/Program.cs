using Contentful.AspNetCore;
using Dfe.ContentSupport.Web.Extensions;
using GovUk.Frontend.AspNetCore;

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

app.MapControllerRoute(name: "sitemap",
    pattern: "sitemap.xml",
    defaults: new { controller = "Sitemap", action = "Index" }
    );

app.MapControllerRoute(
    name: "default/{slug}",
    pattern: "{slug?}",
    defaults: new { controller = "Home", action = "Index" }
    );

app.Run();