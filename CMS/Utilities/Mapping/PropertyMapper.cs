using CMS.Data.EF.Entities;
using CMS.Models;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CMS.Utilities.Mapping
{
    public static class PropertyMapper
    {
        public static PropertyModel Map(Property entity)
        {            
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            
            return new PropertyModel() { Name = entity.Name, Type = entity.Type, Value = entity.Values.SingleOrDefault(x => x.LanguageCode == currentCulture.Name)?.Value };
        }

        public static IList<PropertyModel> Map(IList<Property> entities) => entities.Select(x => PropertyMapper.Map(x)).ToList();
    }
}