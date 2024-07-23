using Dfe.ContentSupport.Web.Configuration;
using Contentful.Core.Errors;
using Contentful.Core.Search;
using Dfe.ContentSupport.Web.Http;

namespace Dfe.ContentSupport.Web.Tests.Http;

public class HttpContentfulClientTests
{
    [Fact]
    public async Task Client_Calls_Contentful_And_Bounce()
    {
        var sut = new HttpContentfulClient(new HttpClient(), new CsContentfulOptions());

        await sut.Invoking(o => o.Query(new QueryBuilder<dynamic>())).Should()
            .ThrowExactlyAsync<ContentfulException>()
            .WithMessage("The resource could not be found.");
    }
}