using System.Linq;
using System.Text;

namespace Dfe.ContentSupport.Web.Services;

public class TextRenderer : NodeRenderer
{
    public override void Render(dynamic node, StringBuilder sb)
    {
        var marks = node.marks as IEnumerable<dynamic>;
        var isBold = marks != null && marks.Any(mark => mark.type == "bold");

        if (isBold)
        {
            sb.Append("<strong>");
        }

        sb.Append(node.value);

        if (isBold)
        {
            sb.Append("</strong>");
        }

        if (string.IsNullOrEmpty(node.value.ToString()))
        {
            sb.Append("<br>");
        }
    }
}
