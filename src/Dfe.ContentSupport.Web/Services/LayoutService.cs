using Dfe.ContentSupport.Web.Models;
using Dfe.ContentSupport.Web.Models.Mapped;


namespace Dfe.ContentSupport.Web.Services
{
    public class LayoutService : ILayoutService
    {
        public CsPage GenerateLayout(CsPage page, HttpRequest request, string pageName)
        {
            if (!page.ShowVerticalNavigation) return page;

            return new()
            {
                Heading = GetHeading(page, pageName),
                MenuItems = GenerateVerticalNavigation(page, request, pageName),
                Content = GetVisiblePageList(page, pageName),
                UpdatedAt = page.UpdatedAt,
                CreatedAt = page.CreatedAt,
                HasCitation = page.HasCitation,
                HasBackToTop = page.HasBackToTop,
                IsSitemap = page.IsSitemap,
                ShowVerticalNavigation = page.ShowVerticalNavigation,
                Slug = page.Slug,
            };
        }


        public Heading GetHeading(CsPage page, string pageName)
        {
            var selectedPage = page.Content.Find(o => o.InternalName == pageName);

            if (selectedPage != null)
                return new()
                {
                    Title = selectedPage.Title ?? "",
                    Subtitle = selectedPage.Subtitle ?? ""
                };


            return new()
            {
                Title = page.Content[0]?.Title ?? "",
                Subtitle = page.Content[0]?.Subtitle ?? ""
            };
        }


        public List<PageLink> GenerateVerticalNavigation(CsPage page, HttpRequest request, string pageName)
        {
            var baseUrl = GetNavigationUrl(request);

            var menuItems = page.Content.Select(o => new PageLink()
            {
                Title = o.Title ?? "",
                Subtitle = o.Subtitle ?? "",
                Url = $"{baseUrl}/{o.InternalName}",
                IsActive = pageName == o.InternalName
            }).ToList();

            if (string.IsNullOrEmpty(pageName) && menuItems.Count > 0)
                menuItems[0].IsActive = true;

            return menuItems;
        }


        public List<CsContentItem> GetVisiblePageList(CsPage page, string pageName)
        {
            if (!string.IsNullOrEmpty(pageName))
                return page.Content.Where(o => o.InternalName == pageName).ToList();


            return page.Content.GetRange(0, 1);

        }


        public string GetNavigationUrl(HttpRequest request)
        {
            var splitUrl = request.Path.ToString().Split("/");
            return string.Join("/", splitUrl.Take(3));
        }


    }
}
