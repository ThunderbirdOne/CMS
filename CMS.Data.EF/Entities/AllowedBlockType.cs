using System;

namespace CMS.Data.EF.Entities
{
    public class AllowedBlockType : AuditedEntity
    {        
        public Guid Parentype { get; set; }

        public virtual BlockType Parent { get; set; }


        public Guid AllowedSubType { get; set; }

        public virtual BlockType SubType { get; set; }
    }
}