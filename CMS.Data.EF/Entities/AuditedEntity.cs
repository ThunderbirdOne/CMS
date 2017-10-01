using System;

namespace CMS.Data.EF.Entities
{
    public abstract class AuditedEntity : BaseEntity
    {
        public DateTime Created { get; set; }

        public string CreateUser { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string UpdateUser { get; set; }
    }
}
