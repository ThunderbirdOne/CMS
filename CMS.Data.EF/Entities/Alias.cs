using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public class Alias : AuditedEntity
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public string LanguageCode { get; set; }

        //one-to-manies
        public Guid PageId { get; set; }

        public Page Page { get; set; }
    }
}