using System;
using System.Collections.Generic;

namespace CMS.Data.EF.Entities
{
    public class BlockType : AuditedEntity
    {        
        public BlockType()
        {
            AllowedChildTypes = new List<AllowedBlockType>();
        }

        public string Name { get; set; }

        public bool AllowAtRoot { get; set; }

        public IList<AllowedBlockType> AllowedChildTypes { get; set; }

        public void AddChildTypes(IList<BlockType> types)
        {
            foreach(var type in types)
            {
                AllowedChildTypes.Add(new AllowedBlockType { Parent = this, SubType = type, Created = DateTime.Now, CreateUser = "Me" });
            }
        }
    }
}
