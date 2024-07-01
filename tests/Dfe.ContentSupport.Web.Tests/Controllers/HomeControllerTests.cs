using Dfe.ContentSupport.Web.Controllers;
using Dfe.ContentSupport.Web.Models.Mapped;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Tests.Controllers;

public class HomeControllerTests
{
    private readonly Mock<IContentService> _contentServiceMock = new();

    private HomeController GetController()
    {
        return new HomeController(_contentServiceMock.Object);
    }


    [Fact]
    public async void Home_Returns_View()
    {
        _contentServiceMock.Setup(o => o.GetCsPages()).ReturnsAsync([]);

        var sut = GetController();
        var result = await sut.Home();

        result.Should().BeOfType<ViewResult>();
        (result as ViewResult)!.Model.Should().BeOfType<CsPage>();
    }

    [Fact]
    public async void Index_NoSlug_Returns_ErrorAction()
    {
        var sut = GetController();

        var result = await sut.Index(string.Empty);

        result.Should().BeOfType<RedirectToActionResult>();
        (result as RedirectToActionResult)!.ActionName.Should().BeEquivalentTo("error");
    }

    [Fact]
    public async void Index_Calls_Service_GetContent()
    {
        const string dummySlug = "dummySlug";
        const bool isPreview = true;
        var sut = GetController();

        await sut.Index(dummySlug, isPreview);

        _contentServiceMock.Verify(o => o.GetContent(dummySlug, isPreview), Times.Once);
    }

    [Fact]
    public async void Index_NullResponse_ReturnsErrorAction()
    {
        _contentServiceMock.Setup(o => o.GetContent(It.IsAny<string>(), It.IsAny<bool>()))
            .ReturnsAsync((CsPage?)null);

        var sut = GetController();

        var result = await sut.Index("slug");

        result.Should().BeOfType<RedirectToActionResult>();
        (result as RedirectToActionResult)!.ActionName.Should().BeEquivalentTo("error");
    }

    [Fact]
    public async void Index_WithSlug_Returns_View()
    {
        _contentServiceMock.Setup(o => o.GetContent(It.IsAny<string>(), It.IsAny<bool>()))
            .ReturnsAsync(new CsPage(new ContentSupportPage()));

        var sut = GetController();
        var result = await sut.Index("slug1");

        result.Should().BeOfType<ViewResult>();
        (result as ViewResult)!.Model.Should().BeOfType<CsPage>();
    }

    [Fact]
    public void Privacy_Returns_EmptyView()
    {
        var sut = GetController();

        var result = sut.Privacy();

        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Error_Returns_ErrorView()
    {
        var sut = GetController();
        sut.ControllerContext.HttpContext = new DefaultHttpContext();
        var result = sut.Error();

        result.Should().BeOfType<ViewResult>();
        (result as ViewResult)!.Model.Should().BeOfType<ErrorViewModel>();
    }
}