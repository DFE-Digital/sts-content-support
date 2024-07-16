using Newtonsoft.Json;
using File = System.IO.File;

namespace Dfe.ContentSupport.Web.Tests;

public static class Data
{
    public static ContentSupportPage ContentSupportPage1 =>
        JsonConvert.DeserializeObject<ContentSupportPage>(File.ReadAllText(
            "DummyContentSupportPage.json"))!;
}