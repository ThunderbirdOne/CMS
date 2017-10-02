using CMS.Utilities.ViewRendering;
using System.Collections.Generic;
using System.Text;

namespace CMS.Models
{
    public class ContentBlockModel : BlockModel
    {
        public string PartialViewPath { get; set; }

        public Dictionary<string, string> Properties { get; set; }

        public override string Render()
        {
            var htmlResult = new StringBuilder();

            htmlResult.AppendLine(ViewRenderer.RenverViewToString(PartialViewPath, Properties, true));

            return htmlResult.ToString();
        }
    }
}