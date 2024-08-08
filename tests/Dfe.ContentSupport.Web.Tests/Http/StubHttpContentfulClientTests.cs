using Dfe.ContentSupport.Web.Configuration;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.Http;

namespace Dfe.ContentSupport.Web.Tests.Http;

public class StubHttpContentfulClientTests
{
    [Fact]
    public async Task Client_Get_MockContent()
    {
        var sut = new StubHttpContentfulClient(new HttpClient(), new CsContentfulOptions());

        var collection = await sut.Query(It.IsAny<QueryBuilder<ContentSupportPage>>());
        collection.First().InternalName.Should().BeEquivalentTo("MockContent");
    }
}