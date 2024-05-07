namespace Dfe.ContentSupport.Web.Models
{
    public class Page
    {
        public string InternalName { get; init; } = null!;

        public string Slug { get; init; } = null!;

        public bool DisplayBackButton { get; init; }

        public bool DisplayHomeButton { get; init; }

        public bool DisplayTopicTitle { get; init; }

        public bool DisplayOrganisationName { get; init; }

        public bool RequiresAuthorisation { get; init; } = true;

        public string? SectionTitle { get; set; }

        public List<dynamic> BeforeTitleContent { get; init; } = [];

        public string Title { get; set; } = null;

        public string? OrganisationName { get; set; }

        public List<dynamic> Content { get; init; } = [];
    }
}
