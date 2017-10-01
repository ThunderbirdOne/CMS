using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public abstract class BlockModel
    {
        public BlockModel()
        {
            Children = new List<BlockModel>();
        }

        public Guid Id { get; set; }

        public int Position { get; set; }

        public BlockModel Parent { get; set; }

        public IList<BlockModel> Children { get; set; }

        public virtual string Render()
        {
            throw new NotImplementedException("use subclass to render");
        }
    }
}