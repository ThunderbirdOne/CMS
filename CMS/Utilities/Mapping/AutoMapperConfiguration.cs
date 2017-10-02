using AutoMapper;

namespace CMS.Utilities.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CMSProfile>();
            });
        }
    }
}