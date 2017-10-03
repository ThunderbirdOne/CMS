using CMS.Data.EF.Entities;
using CMS.Models.CMS;

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

            var propertyValue = entity.Values.SingleOrDefault(x => x.LanguageCode == currentCulture.Name)?.Value;
            //Fallback for properties defined for languages (i.e. "en", "fr", ...)
            if (propertyValue == null)
            {
                propertyValue = entity.Values.SingleOrDefault(x => x.LanguageCode.StartsWith(currentCulture.TwoLetterISOLanguageName))?.Value;
            }

            return new PropertyModel() { Name = entity.Name, Type = entity.Type, Value = propertyValue};
        }

        public static IList<PropertyModel> Map(IList<Property> entities) => entities.Select(x => PropertyMapper.Map(x)).ToList();
    }
}