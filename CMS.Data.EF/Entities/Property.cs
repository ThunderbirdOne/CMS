using System;
using System.Collections.Generic;

namespace CMS.Data.EF.Entities
{
    public class Property : AuditedEntity
    {
        public string Name { get; set; }

         public string Type { get; set; }

        //one-to-manies
        public Guid BlockId { get; set; }

        public virtual ContentBlock Block { get; set; }

        public virtual IList<PropertyValue> Values { get; set; }
    }
}