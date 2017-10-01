using System;

namespace CMS.Data.EF.Entities
{
    public class Alias : AuditedEntity
    {
        public string Url { get; set; }

        public string LanguageCode { get; set; }

        //one-to-manies
        public Guid PageId { get; set; }

        public Page Page { get; set; }
    }
}