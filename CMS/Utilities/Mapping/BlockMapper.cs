using CMS.Data.EF.Constants;
using CMS.Data.EF.Entities;
using CMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Utilities.Mapping
{
    public static partial class BlockMapper
    {
        public static BlockModel Map(Block entity)
        {
            if (entity == null) return null;

            switch(entity.Type)
            {
                case BlockType.BootstrapGrid:
                    return new BootstrapGridModel() { Id = entity.Id, Parent = Map(entity.ParentBlock), Position = entity.Position };
                case BlockType.BootstrapRow:
                    return new BootstrapRowModel() { Id = entity.Id, Position = entity.Position };
                case BlockType.BootstrapBlock:
                    BootstrapBlock block = (BootstrapBlock)entity;
                    return new BootstrapBlockModel() { Id = block.Id, Position = block.Position, Width = block.Width };
                case BlockType.Content:
                    ContentBlock content = (ContentBlock)entity;
                    return new ContentBlockModel() { Id = content.Id, Position = content.Position, PartialViewPath = content.PartialViewPath, Properties = PropertyMapper.Map(content.Properties).ToDictionary(x => x.Name, x => x.Value) };
                default:
                    return null;
            }
        }

        public static IEnumerable<BlockModel> Map(IEnumerable<Block> entities) => entities.Select(x => BlockMapper.Map(x));
    }
}