using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public class Media : AuditedEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Value { get; set; }

        [Required]
        public string Type { get; set; }

        public Guid? ReferenceMediaId { get; set; }

        public virtual Media ReferenceMedia { get; set; }

        public virtual List<Media> ReferencedBy { get; set; }
    }
}
