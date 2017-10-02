using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.EF.Entities
{
    [Table("ContentBlock")]
    public class ContentBlock : Block
    {
        [Required]
        public string PartialViewPath { get; set; }

        public virtual IList<Property> Properties { get; set; }
    }
}
