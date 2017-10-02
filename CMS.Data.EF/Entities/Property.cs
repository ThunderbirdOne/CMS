using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public class Property : AuditedEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        //one-to-manies
        public Guid BlockId { get; set; }

        public virtual ContentBlock Block { get; set; }

        public virtual IList<PropertyValue> Values { get; set; }
    }
}