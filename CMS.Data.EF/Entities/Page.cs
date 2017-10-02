using System;
using System.Collections.Generic;

namespace CMS.Data.EF.Entities
{
    public class Page : AuditedEntity
    {
        public string Name { get; set; }

        public PageType Type { get; set; }

        //one-to-manies
        public Guid? ParentPageId { get; set; }

        public virtual Page ParentPage { get; set; }

        public virtual IList<Alias> Aliases { get; set; }

        public virtual IList<Block> Blocks { get; set; }

        public virtual IList<Page> ChildPages { get; set; }

        public bool IsPublished { get; set; }
    }
}