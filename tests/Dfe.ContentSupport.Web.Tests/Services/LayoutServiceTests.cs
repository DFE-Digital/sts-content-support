
using Dfe.ContentSupport.Web.Models.Mapped;
using Microsoft.AspNetCore.Http;


namespace Dfe.ContentSupport.Web.Tests.Services
{
    public class LayoutServiceTests
    {
        private readonly LayoutService _layoutService = new();

        [Fact]
        public void GetHeading_PageExists_ReturnsCorrectHeading()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new()
            {
                new () { InternalName = "Home", Title = "Home Title", Subtitle = "Home Subtitle" },
                new () { InternalName = "About", Title = "About Title", Subtitle = "About Subtitle" }
            }
            };

            // Act
            var result = _layoutService.GetHeading(page, "About");

            // Assert
            Assert.Equal("About Title", result.Title);
            Assert.Equal("About Subtitle", result.Subtitle);
        }

        [Fact]
        public void GetHeading_PageDoesNotExist_ReturnsFirstPageHeading()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new()
            {
                new () { InternalName = "Home", Title = "Home Title", Subtitle = "Home Subtitle" },
                new () { InternalName = "About", Title = "About Title", Subtitle = "About Subtitle" }
            }
            };

            // Act
            var result = _layoutService.GetHeading(page, "Contact");

            // Assert
            Assert.Equal("Home Title", result.Title);
            Assert.Equal("Home Subtitle", result.Subtitle);
        }


        [Fact]
        public void GetHeading_PageExistsWithNullTitleAndSubtitle_ReturnsEmptyStrings()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new()
            {
                new () { InternalName = "Home", Title = "Home Title", Subtitle = "Home Subtitle" },
                new () { InternalName = "About", Title = null, Subtitle = null }
            }
            };

            // Act
            var result = _layoutService.GetHeading(page, "About");

            // Assert
            Assert.Equal("", result.Title);
            Assert.Equal("", result.Subtitle);
        }



        [Fact]
        public void GenerateVerticalNavigation_PageNameMatches_ReturnsCorrectMenuItems()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new()
            {
                new()  { InternalName = "Home", Title = "Home Title", Subtitle = "Home Subtitle" },
                new()  { InternalName = "About", Title = "About Title", Subtitle = "About Subtitle" }
            }
            };

            var request = new DefaultHttpContext().Request;

            // Act
            var result = _layoutService.GenerateVerticalNavigation(page, request, "About");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("About Title", result[1].Title);
            Assert.True(result[1].IsActive);
        }


        [Fact]
        public void GenerateVerticalNavigation_PageNameDoesNotMatch_ReturnsMenuItemsWithFirstActive()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new()
            {
                new () { InternalName = "Home", Title = "Home Title", Subtitle = "Home Subtitle" },
                new () { InternalName = "About", Title = "About Title", Subtitle = "About Subtitle" }
            }
            };

            var request = new DefaultHttpContext().Request;

            // Act
            var result = _layoutService.GenerateVerticalNavigation(page, request, "Contact");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Home Title", result[0].Title);
            Assert.Equal(0, result.Count(o => o.IsActive));
        }


        [Fact]
        public void GetVisiblePageList_PageNameProvidedAndMatches_ReturnsMatchingItems()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new List<CsContentItem>
            {
                new CsContentItem { InternalName = "Home" },
                new CsContentItem { InternalName = "About" }
            }
            };


            // Act
            var result = _layoutService.GetVisiblePageList(page, "About");

            // Assert
            Assert.Single(result);
            Assert.Equal("About", result[0].InternalName);
        }

        [Fact]
        public void GetVisiblePageList_PageNameProvidedAndDoesNotMatch_ReturnsEmptyList()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new List<CsContentItem>
            {
                new CsContentItem { InternalName = "Home" },
                new CsContentItem { InternalName = "About" }
            }
            };


            // Act
            var result = _layoutService.GetVisiblePageList(page, "Contact");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetVisiblePageList_PageNameIsNullOrEmpty_ReturnsFirstItem()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new List<CsContentItem>
            {
                new CsContentItem { InternalName = "Home" },
                new CsContentItem { InternalName = "About" }
            }
            };


            // Act
            var result = _layoutService.GetVisiblePageList(page, "");

            // Assert
            Assert.Single(result);
            Assert.Equal("Home", result[0].InternalName);
        }

        [Fact]
        public void GetVisiblePageList_ContentListIsEmpty_ReturnsEmptyList()
        {
            // Arrange
            var page = new CsPage
            {
                Content = new List<CsContentItem>()
            };


            // Act
            var result = _layoutService.GetVisiblePageList(page, "Home");

            // Assert
            Assert.Empty(result);
        }


        [Fact]
        public void GetNavigationUrl_MoreThanTwoSegments_ReturnsFirstTwoSegments()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "/segment1/segment2/segment3/segment4";

            // Act
            var result = _layoutService.GetNavigationUrl(context.Request);

            // Assert
            Assert.Equal("/segment1/segment2", result);
        }

        [Fact]
        public void GetNavigationUrl_ExactlyTwoSegments_ReturnsAllSegments()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "/segment1/segment2";


            // Act
            var result = _layoutService.GetNavigationUrl(context.Request);

            // Assert
            Assert.Equal("/segment1/segment2", result);
        }

        [Fact]
        public void GetNavigationUrl_FewerThanTwoSegments_ReturnsAllSegments()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "/segment1";


            // Act
            var result = _layoutService.GetNavigationUrl(context.Request);

            // Assert
            Assert.Equal("/segment1", result);
        }

        [Fact]
        public void GetNavigationUrl_EmptyUrl_ReturnsEmptyString()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "";

            // Act
            var result = _layoutService.GetNavigationUrl(context.Request);

            // Assert
            Assert.Equal("", result);
        }

    }
}
