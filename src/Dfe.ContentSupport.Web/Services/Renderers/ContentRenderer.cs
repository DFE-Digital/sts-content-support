using System.Text;
using Dfe.ContentSupport.Web.Models;
using Newtonsoft.Json.Linq;

namespace Dfe.ContentSupport.Web.Services;

public class ContentRenderer : IContentRenderer
{
    public string Render(ContentSupportPage page)
    {
        var sb = new StringBuilder();

        sb.Append("<h1>");
        sb.Append(page.Title.Text);
        sb.Append("</h1>");

        foreach (var content in page.Content)
        {
            var richTextJson = content["richText"] as JObject;

            if (richTextJson != null && richTextJson["nodeType"] != null)
            {
                NodeRenderer renderer = NodeRendererFactory.Create(
                    richTextJson["nodeType"].ToString()
                );

                if (renderer != null)
                {
                    renderer.Render(richTextJson, sb);
                }
            }
        }

        return sb.ToString();
    }
}
