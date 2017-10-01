using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Models
{
    public class PageModel
    {
        public string Name { get; set; }

        public IEnumerable<BlockModel> Blocks { get; set; }

        public PageModel()
        {
            Blocks = new List<BlockModel>();
        }

        public PageModel(IEnumerable<BlockModel> blocks)
        {
            Blocks = blocks;
        }

        public string RenderHtml
        {
            get
            {
                var htmlResult = new StringBuilder();

                var rootBlocks = Blocks.Where(b => b.Parent == null);
                foreach(var rootBlock in rootBlocks)
                {
                    htmlResult.AppendLine(rootBlock.Render());
                }

                return htmlResult.ToString();
            }
        }
    }
}