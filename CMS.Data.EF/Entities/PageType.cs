using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public class PageType : AuditedEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool AllowAtRoot { get; set; }

        //one-to-manies
        public virtual IList<Page> Pages { get; set; }
        
        public virtual IList<PageTypePreset> AllowedPresets { get; set; }
    }
}