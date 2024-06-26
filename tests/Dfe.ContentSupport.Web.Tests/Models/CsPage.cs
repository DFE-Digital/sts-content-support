using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Models.Mapped;
using Dfe.ContentSupport.Web.Models.Mapped.Custom;
using Dfe.ContentSupport.Web.Models.Mapped.Standard;
using Dfe.ContentSupport.Web.Models.Mapped.Types;
using FileDetails = Dfe.ContentSupport.Web.Models.FileDetails;

namespace Dfe.ContentSupport.Web.Tests.Models;

public class CsPageTests
{
    [Fact]
    public void ShouldMapCorrectly()
    {
        var contentSupportPage = Data.ContentSupportPage1;

        var result = new CsPage(contentSupportPage);

        result.IsSitemap.Should().BeTrue();
        result.Heading.Should().BeEquivalentTo(contentSupportPage.Heading);
        result.Content.Should().ContainSingle();

        var pageContent = result.Content.First();

        pageContent.Should().BeOfType<RichTextContentItem>();

        //RichTextCorrect(pageContent, contentSupportPage.Content.First());
    }


    [Fact]
    public void EmbeddedAssetCorrectContentType()
    {
        var asset = new Fields
        {
            File = new FileDetails
            {
                ContentType = "image/jpeg",
                Url = "uri"
            },
            Title = "title",
            Description = "description",
        };

        new EmbeddedAsset(asset, "internalName").AssetContentType.Should()
            .Be(AssetContentType.Image);
        asset.File.ContentType = "image/png";
        new EmbeddedAsset(asset, "internalName").AssetContentType.Should()
            .Be(AssetContentType.Image);
        asset.File.ContentType = "video/mp4";
        new EmbeddedAsset(asset, "internalName").AssetContentType.Should()
            .Be(AssetContentType.Video);
        asset.File.ContentType = "video/quicktime";
        new EmbeddedAsset(asset, "internalName").AssetContentType.Should()
            .Be(AssetContentType.Video);
        asset.File.ContentType = "dummy";
        new EmbeddedAsset(asset, "internalName").AssetContentType.Should()
            .Be(AssetContentType.Unknown);


        var embeddedAsset = new EmbeddedAsset(asset, "internalName");
        embeddedAsset.Title.Should().Be("title");
        embeddedAsset.Description.Should().Be("description");
        embeddedAsset.Uri.Should().Be("uri");
        embeddedAsset.NodeType.Should().Be(RichTextNodeType.EmbeddedAsset);
    }

    [Fact]
    public void CardsMapCorrectly()
    {
        var target = new Target
        {
            Title = "title",
            Description = "description",
            Meta = "meta",
            Uri = "uri",
            ImageAlt = "imageAlt",
            Image = new Image
            {
                Fields = new Fields
                {
                    File = new FileDetails
                    {
                        Url = "imageUri"
                    }
                }
            }
        };

        var card = new CustomCard(target);
        card.Description.Should().Be("description");
        card.ImageAlt.Should().Be("imageAlt");
        card.ImageUri.Should().Be("imageUri");
        card.Meta.Should().Be("meta");
        card.Title.Should().Be("title");
        card.Uri.Should().Be("uri");
    }

    [Fact]
    public void GridContainerMapCorrectly()
    {
        var target = new Target
        {
            Content =
            [
                new Target
                {
                    Title = "title",
                    Description = "description",
                    Meta = "meta",
                    Uri = "uri",
                    ImageAlt = "imageAlt",
                    Image = new Image
                    {
                        Fields = new Fields
                        {
                            File = new FileDetails
                            {
                                Url = "imageUri"
                            }
                        }
                    }
                }
            ]
        };

        var grid = new CustomGridContainer(target);
        grid.Cards.Should().HaveCount(1);
        var card = grid.Cards.First();
        card.Description.Should().Be("description");
        card.ImageAlt.Should().Be("imageAlt");
        card.ImageUri.Should().Be("imageUri");
        card.Meta.Should().Be("meta");
        card.Title.Should().Be("title");
        card.Uri.Should().Be("uri");
    }
}