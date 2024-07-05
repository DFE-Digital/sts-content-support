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
    private readonly Mock<ICacheService<List<CsPage>>> _cacheMock = new();


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
        return new ContentService(GetClient(), _cacheMock.Object);
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
        SetupResponse();
        await sut.GetContent(It.IsAny<string>());

        _httpContentClientMock.Verify(o =>
                o.Query(
                    It.IsAny<QueryBuilder<ContentSupportPage>>(),
                    It.IsAny<CancellationToken>()),
            Times.Once
        );
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

    [Fact]
    public async void GetCsPages_Calls_Client_Once()
    {
        SetupResponse();
        var sut = GetService();
        await sut.GetCsPages();

        _httpContentClientMock.Verify(o =>
                o.Query(
                    It.IsAny<QueryBuilder<ContentSupportPage>>(),
                    It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GetCsPages_NotPreview_Calls_Cache_Correct_Key()
    {
        const string expectedKey = "IsSitemap_true";
        SetupResponse();
        var sut = GetService();
        await sut.GetCsPages(false);

        _cacheMock.Verify(o => o.GetFromCache(expectedKey), Times.Once);
    }

    [Fact]
    public async void GetCsPages_Preview_Calls_Cache_Correct_Key()
    {
        const string expectedKey = "IsSitemap_true";
        SetupResponse();
        var sut = GetService();
        await sut.GetCsPages();

        _cacheMock.Verify(o => o.GetFromCache(expectedKey), Times.Never);
    }

    [Fact]
    public async void GetCsPages_NotPreview_Calls_AddCache_Correct_Key()
    {
        const string expectedKey = "IsSitemap_true";
        SetupResponse();
        var sut = GetService();
        await sut.GetCsPages(false);

        _cacheMock.Verify(o => o.AddToCache(expectedKey, It.IsAny<List<CsPage>>()), Times.Once);
    }

    [Fact]
    public async void GetCsPages_Preview_Calls_AddCache_Correct_Key()
    {
        const string expectedKey = "IsSitemap_true";
        SetupResponse();
        var sut = GetService();
        await sut.GetCsPages();

        _cacheMock.Verify(o => o.AddToCache(expectedKey, It.IsAny<List<CsPage>>()), Times.Never);
    }

    [Fact]
    public async void GetContent_Calls_Cache_Correct_Key()
    {
        const string slug = "dummy-slug";
        const string expectedKey = $"Slug_{slug}";
        SetupResponse();
        var sut = GetService();
        await sut.GetContent(slug, It.IsAny<bool>());

        _cacheMock.Verify(o => o.GetFromCache(expectedKey));
    }

    [Fact]
    public async void GetCsPage_Calls_Cache_Correct_Key()
    {
        const string slug = "dummy-slug";
        const string expectedKey = $"Slug_{slug}";
        SetupResponse();
        var sut = GetService();
        await sut.GetContent(slug, It.IsAny<bool>());

        _cacheMock.Verify(o => o.GetFromCache(expectedKey));
    }

    [Fact]
    public async void GetContentSupportPages_Calls_Cache_Correct_Key()
    {
        const string field = "field";
        const string value = "value";
        SetupResponse();
        var isPreview = It.IsAny<bool>();
        const string expectedKey = $"{field}_{value}";
        var sut = GetService();
        await sut.GetContentSupportPages(field, value, isPreview);

        _cacheMock.Verify(o => o.GetFromCache(expectedKey));
    }

    [Fact]
    public async void GetContentSupportPages_GotCache_Returns_Cache()
    {
        var cacheValue = new List<CsPage> { It.IsAny<CsPage>() };

        const string field = "field";
        const string value = "value";
        const string expectedKey = $"{field}_{value}";
        var isPreview = It.IsAny<bool>();
        _cacheMock.Setup(o => o.GetFromCache(expectedKey)).Returns(cacheValue);

        var sut = GetService();
        var result = await sut.GetContentSupportPages(field, value, isPreview);

        result.Should().BeEquivalentTo(cacheValue);
    }

    [Fact]
    public async void GetContentSupportPages_NotGotCache_Calls_Client()
    {
        List<CsPage>? cacheValue = null;

        const string field = "field";
        const string value = "value";
        const string expectedKey = $"{field}_{value}";
        SetupResponse();
        var isPreview = It.IsAny<bool>();
        _cacheMock.Setup(o => o.GetFromCache(expectedKey)).Returns(cacheValue);

        var sut = GetService();
        await sut.GetContentSupportPages(field, value, isPreview);

        _httpContentClientMock.Verify(o =>
                o.Query(
                    It.IsAny<QueryBuilder<ContentSupportPage>>(),
                    It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async void GetContentSupportPages_NotGotCache_AddsToCache()
    {
        List<CsPage>? cacheValue = null;

        const string field = "field";
        const string value = "value";
        const string expectedKey = $"{field}_{value}";
        SetupResponse();
        var isPreview = It.IsAny<bool>();
        _cacheMock.Setup(o => o.GetFromCache(expectedKey)).Returns(cacheValue);

        var sut = GetService();
        await sut.GetContentSupportPages(field, value, isPreview);

        _cacheMock.Verify(o => o.AddToCache(expectedKey, It.IsAny<List<CsPage>>()), Times.Once);
    }
}