using CMS.Utilities.ViewRendering;
using System.Collections.Generic;
using System.Text;

namespace CMS.Models
{
    public class ContentBlockModel : BlockModel
    {
        public string PartialViewPath { get; set; }

        public IList<PropertyModel> Properties { get; set; }

        public override string Render()
        {
            var htmlResult = new StringBuilder();

            PageModel model = null;
            htmlResult.AppendLine(ViewRenderer.RenverViewToString(PartialViewPath, model, true));

            return htmlResult.ToString();
        }
    }
}