using Dfe.ContentSupport.Web.Common;
using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Models.Mapped.Standard;
using Dfe.ContentSupport.Web.Models.Mapped.Types;
using FileDetails = Dfe.ContentSupport.Web.Models.FileDetails;

namespace Dfe.ContentSupport.Web.Tests.Models.Mapped.Standard;

public class EmbeddedAssetTests
{
    private static ModelMapper GetService() => new();

    private const string InternalName = "Internal Name";
    private const string ContentType = "Content Type";
    private const string Description = "Description";
    private const string Title = "Title";
    private const string Uri = "Uri";

    private static ContentItem DummyContentItem() => new()
    {
        NodeType = RichTextTags.EmbeddedAsset,
        InternalName = InternalName,
        Data = new Web.Models.Data
        {
            Target = new Target
            {
                Fields = new Fields
                {
                    File = new FileDetails
                    {
                        ContentType = ContentType,
                        Url = Uri
                    },
                    Description = Description,
                    Title = Title
                }
            }
        }
    };


    [Fact]
    public void ImageMapsCorrectly()
    {
        var testValue = DummyContentItem();
        Utilities.ImageSupportedTypes = [ContentType];
        Utilities.VideoSupportedTypes = [];

        var sut = GetService();

        var result = sut.MapContent(testValue)!;
        result.Should().BeAssignableTo<EmbeddedAsset>();
        var asset = (result as EmbeddedAsset)!;

        asset.NodeType.Should().Be(RichTextNodeType.EmbeddedAsset);
        asset.AssetContentType.Should().Be(AssetContentType.Image);
        asset.InternalName.Should().Be(InternalName);
        asset.Description.Should().Be(Description);
        asset.Title.Should().Be(Title);
        asset.Uri.Should().Be(Uri);
    }

    [Fact]
    public void VideoMapsCorrectly()
    {
        var testValue = DummyContentItem();
        Utilities.ImageSupportedTypes = [];
        Utilities.VideoSupportedTypes = [ContentType];

        var sut = GetService();

        var result = sut.MapContent(testValue)!;
        result.Should().BeAssignableTo<EmbeddedAsset>();
        var asset = (result as EmbeddedAsset)!;

        asset.NodeType.Should().Be(RichTextNodeType.EmbeddedAsset);
        asset.AssetContentType.Should().Be(AssetContentType.Video);
        asset.InternalName.Should().Be(InternalName);
        asset.Description.Should().Be(Description);
        asset.Title.Should().Be(Title);
        asset.Uri.Should().Be(Uri);
    }

    [Fact]
    public void UnknownMapsCorrectly()
    {
        var testValue = DummyContentItem();
        Utilities.ImageSupportedTypes = [];
        Utilities.VideoSupportedTypes = [];

        var sut = GetService();

        var result = sut.MapContent(testValue)!;
        result.Should().BeAssignableTo<EmbeddedAsset>();
        var asset = (result as EmbeddedAsset)!;

        asset.NodeType.Should().Be(RichTextNodeType.EmbeddedAsset);
        asset.AssetContentType.Should().Be(AssetContentType.Unknown);
        asset.InternalName.Should().Be(InternalName);
        asset.Description.Should().Be(Description);
        asset.Title.Should().Be(Title);
        asset.Uri.Should().Be(Uri);
    }
}