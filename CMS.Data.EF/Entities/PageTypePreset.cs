using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public class PageTypePreset : BaseEntity
    {
        [Required]
        public Guid PageTypeId { get; set; }

        public virtual PageType PageType { get; set; }

        [Required]
        public Guid PagePresetId { get; set; }

        public virtual PagePreset PagePreset { get; set; }

        public bool IsCustomisable { get; set; }
    }
}
