using CMS.Data.EF.Constants;
using CMS.Data.EF.Entities;
using CMS.Models;
using System.Collections.Generic;

namespace CMS.Utilities.Mapping
{
    public static partial class Mapper
    {
        public static BlockModel Map(Block entity)
        {
            switch(entity.Type)
            {
                case BlockType.BootstrapGrid:
                    return new BootstrapGridModel();
                case BlockType.BootstrapRow:
                    return new BootstrapRowModel();
                case BlockType.BootstrapBlock:
                    return new BootstrapBlockModel();
                case BlockType.Content:
                    return new ContentBlockModel();
                default:
                    return null;
            }
        }

        public static IEnumerable<BlockModel> Map(IEnumerable<Block> entities)
        {
            var result = new List<BlockModel>();
            foreach(var entity in entities)
            {
                result.Add(Mapper.Map(entity));
            }

            return result;
        }
    }
}