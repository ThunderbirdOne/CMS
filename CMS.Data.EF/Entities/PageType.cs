using System;
using System.Collections.Generic;

namespace CMS.Data.EF.Entities
{
    public class PageType : AuditedEntity
    {
        public string Description { get; set; }

        //one-to-manies
        public virtual IList<Page> Pages { get; set; }
    }
}