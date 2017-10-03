using System.Collections.Generic;

namespace CMS.Models.CMS
{
    public class GenericContentModel
    {
        private Dictionary<string, string> _properties;

        public GenericContentModel(Dictionary<string, string> properties)
        {
            _properties = properties;
        }

        public string GetValue(string key)
        {
            if(_properties.ContainsKey(key))
            {
                return _properties[key];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}