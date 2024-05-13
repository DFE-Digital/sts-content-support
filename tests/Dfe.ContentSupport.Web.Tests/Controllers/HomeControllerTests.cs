using Dfe.ContentSupport.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dfe.ContentSupport.Web.Tests.Controllers;

public class HomeControllerTests
{
    private readonly Mock<IContentfulService> _contentfulServiceMock = new();
    private HomeController GetController() => new(_contentfulServiceMock.Object);

    [Fact]
    public void Privacy_Returns_EmptyView()
    {
        var sut = GetController();

        var result = sut.Privacy();

        result.Should().BeOfType<ViewResult>();
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
    public async void Index_WithSlug_Returns_EmptyView()
    {
        _contentfulServiceMock.Setup(o => o.GetContent(It.IsAny<string>()))
            .ReturnsAsync(new ContentSupportPage());

        var sut = GetController();
        var result = await sut.Index("slug1");

        result.Should().BeOfType<ViewResult>();
        (result as ViewResult)!.Model.Should().BeOfType<ContentSupportPage>();
    }

    [Fact]
    public  void Error_Returns_ErrorView()
    {
        var sut = GetController();
        sut.ControllerContext.HttpContext = new DefaultHttpContext();
        var result =  sut.Error();

        result.Should().BeOfType<ViewResult>();
        (result as ViewResult)!.Model.Should().BeOfType<ErrorViewModel>();
    }
}