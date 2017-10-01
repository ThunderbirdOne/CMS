using System.Linq;
using System.Text;

namespace CMS.Models
{
    public class BootstrapGridModel : BlockModel
    {
        public override string Render()
        {
            var htmlResult = new StringBuilder();
            htmlResult.AppendLine("<div class='container'>");

            //add the children if they exist
            if (Children.Any())
            {
                foreach (var child in Children.OrderBy(c => c.Position))
                {
                    htmlResult.AppendLine(child.Render());
                }
            }

            htmlResult.AppendLine("</div>");
            return htmlResult.ToString();
        }
    }
}