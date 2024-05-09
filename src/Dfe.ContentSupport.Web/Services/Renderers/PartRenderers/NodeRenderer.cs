using System.Text;
using Newtonsoft.Json.Linq;

namespace Dfe.ContentSupport.Web.Services;

public abstract class NodeRenderer
{
    public abstract void Render(dynamic node, StringBuilder sb);

    protected void ExploreNode(dynamic node, StringBuilder sb)
    {
        if (node["content"] != null)
        {
            foreach (var childNode in node["content"])
            {
                if (!(childNode is JObject jObject) || jObject["nodeType"] == null)
                {
                    continue;
                }

                String nodeType = childNode["nodeType"].ToString();
                var renderer = NodeRendererFactory.Create(nodeType);

                if (renderer != null)
                {
                    renderer.Render(childNode, sb);
                }
            }
        }
    }
}
