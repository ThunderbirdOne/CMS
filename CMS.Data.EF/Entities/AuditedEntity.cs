using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Data.EF.Entities
{
    public abstract class AuditedEntity : BaseEntity
    {
        public DateTime Created { get; set; }

        [Required]
        public string CreateUser { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string UpdateUser { get; set; }
    }
}
