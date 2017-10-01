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

        public virtual IEnumerable<Alias> Aliases { get; set; }

        public virtual IEnumerable<Block> Blocks { get; set; }

        public virtual IEnumerable<Page> ChildPages { get; set; }
    }
}