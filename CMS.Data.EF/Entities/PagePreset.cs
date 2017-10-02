using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public class PagePreset : AuditedEntity
    {
        [Required]
        public string Name { get; set; }

        public IList<PageTypePreset> PageTypes { get; set; }
        
        public virtual IList<Block> RootBlocks { get; set; }
    }
}
