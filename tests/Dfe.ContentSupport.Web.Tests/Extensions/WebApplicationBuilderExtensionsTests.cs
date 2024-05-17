using Dfe.ContentSupport.Web.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Dfe.ContentSupport.Web.Tests.Extensions;

public class WebApplicationBuilderExtensionsTests
{
    
    [Fact]
    public void Builder_Contains_Correct_Services()
    {
        var builder = WebApplication.CreateBuilder([]);
        builder.InitDependencyInjection();

        var types = new[]
        {
            typeof(IContentfulService)
        };
        foreach (var type in types)
        {
            builder.Services.Where(o => o.ServiceType == type).Should().ContainSingle();
        }
    }
}