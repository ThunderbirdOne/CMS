using CMS.Data.EF.Constants;

using System;
using System.Collections.Generic;

namespace CMS.Data.EF.Entities
{
    public abstract class Block : AuditedEntity
    { 
        public BlockType Type { get; set; }

        public int Position { get; set; }

        //References
        public Guid? ParentBlockId { get; set; }

        public virtual Block ParentBlock { get; set; }

        public Guid? PageId { get; set; }

        public Page Page { get; set; }

        public virtual IEnumerable<Block> ChildBlocks { get; set; }
    }
}