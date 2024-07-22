using Dfe.ContentSupport.Web.Extensions;
using Dfe.ContentSupport.Web.Http;
using Dfe.ContentSupport.Web.Models.Mapped;
using Microsoft.AspNetCore.Builder;

namespace Dfe.ContentSupport.Web.Tests.Extensions;

public class WebApplicationBuilderExtensionsTests
{
    [Fact]
    public void Builder_Contains_Correct_Services()
    {
        var builder = WebApplication.CreateBuilder();
        builder.InitDependencyInjection();

        var types = new[]
        {
            typeof(IContentService),
            typeof(IContentfulService),
            typeof(IHttpContentfulClient),
            typeof(ICacheService<List<CsPage>>),
            typeof(IModelMapper)
        };
        foreach (var type in types)
            builder.Services.Where(o => o.ServiceType == type).Should().ContainSingle();
    }

    [Fact]
    public void Builder_Default_Uses_DefaultClient()
    {
        var builder = WebApplication.CreateBuilder();
        builder.InitDependencyInjection();


        var service = builder.Services.First(o => o.ServiceType == typeof(IHttpContentfulClient));
        service.ImplementationType?.Name.Should().BeEquivalentTo(nameof(HttpContentfulClient));
    }

    [Fact]
    public void Builder_E2e_Uses_MockClient()
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = "e2e"
        });

        builder.InitDependencyInjection();

        var service = builder.Services.First(o => o.ServiceType == typeof(IHttpContentfulClient));
        service.ImplementationType?.Name.Should().BeEquivalentTo(nameof(StubHttpContentfulClient));
    }
}