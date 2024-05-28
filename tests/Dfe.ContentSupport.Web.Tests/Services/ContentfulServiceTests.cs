using Contentful.Core.Configuration;
using Dfe.ContentSupport.Web.Http;

namespace Dfe.ContentSupport.Web.Tests.Services;

public class ContentfulServiceTests
{
    private readonly Mock<IHttpContentfulClient> _httpContentClientMock = new();

    [Fact]
    public void ContentfulClient_Sets_IsPreview()
    {
        var options = new ContentfulOptions();

        var sut = new ContentfulService(options, _httpContentClientMock.Object);

        sut.ContentfulClient(true);
        options.UsePreviewApi.Should().BeTrue();
        sut.ContentfulClient();
        options.UsePreviewApi.Should().BeFalse();
    }
}