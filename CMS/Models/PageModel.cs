using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Models
{
    public class PageModel
    {
        public string Name { get; set; }

        public List<BlockModel> RootBlocks { get; set; }

        public PageModel()
        {
            RootBlocks = new List<BlockModel>();
        }

        public string RenderHtml
        {
            get
            {
                var htmlResult = new StringBuilder();

                foreach(var rootBlock in RootBlocks)
                {
                    htmlResult.AppendLine(rootBlock.Render());
                }

                return htmlResult.ToString();
            }
        }
    }
}