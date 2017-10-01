namespace CMS.Data.EF.Entities
{
    public class PropertyValue : AuditedEntity
    {
        public string Value { get; set; }

        public string LanguageCode { get; set; }
    }
}