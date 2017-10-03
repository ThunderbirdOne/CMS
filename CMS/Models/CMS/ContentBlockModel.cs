using CMS.Utilities.ViewRendering;
using System.Collections.Generic;
using System.Text;

namespace CMS.Models.CMS
{
    public class ContentBlockModel : BlockModel
    {
        public string PartialViewPath { get; set; }

        public GenericContentModel Model { get; set; }

        public override string Render()
        {
            var htmlResult = new StringBuilder();

            htmlResult.AppendLine(ViewRenderer.RenverViewToString(PartialViewPath, Model, true));

            return htmlResult.ToString();
        }
    }
}