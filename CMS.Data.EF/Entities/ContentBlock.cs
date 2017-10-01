using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.EF.Entities
{
    [Table("ContentBlock")]
    public class ContentBlock : Block
    {
        public string PartialViewPath { get; set; }

        public virtual IEnumerable<PropertyValue> PropertyValues { get; set; }
    }
}
