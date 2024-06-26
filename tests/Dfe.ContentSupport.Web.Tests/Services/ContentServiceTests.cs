using System.Xml.Linq;
using Dfe.ContentSupport.Web.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.Http;
using Dfe.ContentSupport.Web.Models.Mapped;

namespace Dfe.ContentSupport.Web.Tests.Services;

public class ContentServiceTests
{
    private readonly Mock<IHttpContentfulClient> _httpContentClientMock = new();


    private readonly ContentfulCollection<ContentSupportPage> _response = new()
    {
        Items = new List<ContentSupportPage>
        {
            new() { Slug = "slug1", IsSitemap = true },
            new() { Slug = "slug2", IsSitemap = false },
            new() { Slug = "slug3", IsSitemap = true }
        }
    };

    private ContentService GetService()
    {
        return new ContentService(GetClient());
    }

    private IContentfulService GetClient()
    {
        return new ContentfulService(new CsContentfulOptions(), _httpContentClientMock.Object);
    }

    private void SetupResponse(ContentfulCollection<ContentSupportPage>? response = null)
    {
        _httpContentClientMock.Setup(o => o.Query(It.IsAny<QueryBuilder<ContentSupportPage>>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(response ?? _response);
    }

    [Fact]
    public async void GetContent_Calls_Client_Once()
    {
        var sut = GetService();
        await sut.GetContent(It.IsAny<string>());

        _httpContentClientMock.Verify(o =>
                o.Query(
                    It.IsAny<QueryBuilder<ContentSupportPage>>(),
                    It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GetContent_NullResponse_Returns_Null()
    {
        var sut = GetService();
        var result = await sut.GetContent(It.IsAny<string>());

        result.Should().BeNull();
    }

    [Fact]
    public async void GetContent_EmptyResponse_Returns_Null()
    {
        SetupResponse(new ContentfulCollection<ContentSupportPage> { Items = [] });

        var sut = GetService();
        var result = await sut.GetContent(It.IsAny<string>());

        result.Should().BeNull();
    }

    [Fact]
    public async void GetContent_Returns_First_Result()
    {
        SetupResponse();

        var sut = GetService();
        var result = await sut.GetContent(It.IsAny<string>());

        result.Should().BeEquivalentTo(new CsPage(_response.Items.First()));
    }

    [Fact]
    public async void GenerateSitemap_Should_Generate_Expected()
    {
        const string expectedStr =
            """<?xml version="1.0" encoding="UTF-8" standalone="no"?><urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"><url><loc>DUMMY_slug1</loc><changefreq>yearly</changefreq></url><url><loc>DUMMY_slug2</loc><changefreq>yearly</changefreq></url><url><loc>DUMMY_slug3</loc><changefreq>yearly</changefreq></url></urlset>""";
        SetupResponse();

        var expected = XDocument.Parse(expectedStr);
        var sut = GetService();
        var resultStr = await sut.GenerateSitemap("DUMMY_");
        var result = XDocument.Parse(resultStr);

        result.Should().BeEquivalentTo(expected);
    }
}