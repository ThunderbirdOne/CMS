using System.Collections.Generic;
using System.Text;

namespace CMS.Models
{
    public class ContentBlockModel : BlockModel
    {
        public string PartialViewPath { get; set; }

        public IEnumerable<PropertyModel> Properties { get; set; }

        public override string Render()
        {
            var htmlResult = new StringBuilder();

            htmlResult.AppendLine("render content here");

            return htmlResult.ToString();
        }
    }
}