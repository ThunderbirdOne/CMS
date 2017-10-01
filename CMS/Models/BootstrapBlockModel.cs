using System.Linq;
using System.Text;

namespace CMS.Models
{
    public class BootstrapBlockModel : BlockModel
    {
        private string classFormat = "<div class='col-{0} col-sm-{0} col-md-{0} col-lg-{0} col-xl-{0}'>";

        public int Width { get; set; }

        public override string Render()
        {
            var htmlResult = new StringBuilder();
            htmlResult.AppendLine(string.Format(classFormat, Width));

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