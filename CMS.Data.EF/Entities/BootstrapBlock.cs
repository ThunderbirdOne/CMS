using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.EF.Entities
{
    [Table("BootstrapBlock")]
    public class BootstrapBlock : Block
    {
        public int Width { get; set; }
    }
}
