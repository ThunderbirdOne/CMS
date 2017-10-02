using CMS.Data.EF.Constants;

using System;
using System.Collections.Generic;

namespace CMS.Data.EF.Entities
{
    public class Block : AuditedEntity
    {
        public Block()
        {
            ChildBlocks = new List<Block>();
        }

        public BlockType Type { get; set; }

        public int Position { get; set; }

        //References
        public Guid? ParentBlockId { get; set; }

        public virtual Block ParentBlock { get; set; }

        public Guid? PageId { get; set; }

        public Page Page { get; set; }

        public virtual IList<Block> ChildBlocks { get; set; }

        public Guid? PagePresetId { get; set; }

        public virtual PagePreset PagePreset { get; set; }

        public void AddChild(Block child, bool fromParent = false)
        {
            ChildBlocks.Add(child);

            if(!fromParent)
                child.AddParent(this, true);
        }

        public void AddParent(Block parent, bool fromChild = false)
        {
            ParentBlock = parent;
            ParentBlockId = parent.Id;

            if(!fromChild)
                parent.AddChild(this, true);
        }

        public bool IsPreset
        {
            get
            {
                return PagePresetId.HasValue && !PageId.HasValue;
            }
        }
    }
}