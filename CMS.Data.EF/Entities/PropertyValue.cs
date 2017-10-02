using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public class PropertyValue : AuditedEntity
    {
        [Required]
        public string Value { get; set; }

        [Required]
        public string LanguageCode { get; set; }
        
        [Required]
        public Guid PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}