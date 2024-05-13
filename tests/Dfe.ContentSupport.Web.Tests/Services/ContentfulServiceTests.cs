using System.Xml.Linq;
using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;

namespace Dfe.ContentSupport.Web.Tests.Services;

public class ContentfulServiceTests
{
    private readonly Mock<IContentfulClient> _contentfulClientMock = new();
    private readonly ContentfulCollection<ContentSupportPage> _response = new()
    {
        Items = new List<ContentSupportPage>
        {
            new() { Slug = "slug1", IsSitemap = true},
            new() { Slug = "slug2",  IsSitemap = false},
            new() { Slug = "slug3",  IsSitemap = true},
        }
    };

    private ContentfulService GetService() => new(_contentfulClientMock.Object);

    private void SetupResponse()
    {
        _contentfulClientMock.Setup(o => o.GetEntries(It.IsAny<QueryBuilder<ContentSupportPage>>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(
            _response);
    }
    
    
    [Fact]
    public async void GetContent_Calls_Client_Once()
    {
        var sut = GetService();
        await sut.GetContent(It.IsAny<string>());

        _contentfulClientMock.Verify(o =>
                o.GetEntries(
                    It.IsAny<QueryBuilder<ContentSupportPage>>(),
                    It.IsAny<CancellationToken>()),
            Times.Once
        );
    }
    
    [Fact]
    public async void GetContent_NullResponse_Returns_EmptyPage()
    {
        var sut = GetService();
        var result = await sut.GetContent(It.IsAny<string>());

        result.Should().BeEquivalentTo(new ContentSupportPage());
    }

    [Fact]
    public async void GetContent_Returns_First_Result()
    {
        SetupResponse();
        
        var sut = GetService();
        var result = await sut.GetContent(It.IsAny<string>());

        result.Should().BeEquivalentTo(_response.Items.First());
    }
    
    [Fact]
    public async void GenerateSitemap_Should_Generate_Expected()
    {
        const string expectedStr = """<?xml version="1.0" encoding="UTF-8" standalone="no"?><urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"><url><loc>DUMMYslug1</loc><changefreq>yearly</changefreq></url><url><loc>DUMMYslug2</loc><changefreq>yearly</changefreq></url><url><loc>DUMMYslug3</loc><changefreq>yearly</changefreq></url></urlset>""";
        SetupResponse();
        
        var expected =XDocument.Parse(expectedStr);
        var sut = GetService();
        var resultStr = await sut.GenerateSitemap("DUMMY");
        var result = XDocument.Parse(resultStr);

        result.Should().BeEquivalentTo(expected);
    }
}