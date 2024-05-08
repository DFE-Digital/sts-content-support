using Contentful.AspNetCore;
using GovUk.Frontend.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddContentful(builder.Configuration);
builder.Services.AddTransient<IContentfulService, ContentfulService>();
builder.Services.AddGovUkFrontend();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
