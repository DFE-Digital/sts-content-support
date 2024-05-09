using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class DocumentRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        sb.Append("<div>");

        ExploreNode(node, sb);

        sb.Append("</div>");
    }
}
