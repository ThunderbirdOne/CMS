using CMS.Data.EF.Constants;
using CMS.Data.EF.Entities;
using CMS.Models.CMS;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Utilities.Mapping
{
    public static partial class BlockMapper
    {
        public static BlockModel Map(Block entity)
        {
            if (entity == null) return null;

            switch(entity.Type.Name)
            {
                case BlockTypes.BootstrapGrid:
                    return new BootstrapGridModel() { Id = entity.Id, Parent = Map(entity.ParentBlock), Position = entity.Position };
                case BlockTypes.BootstrapRow:
                    return new BootstrapRowModel() { Id = entity.Id, Position = entity.Position };
                case BlockTypes.BootstrapBlock:
                    BootstrapBlock block = (BootstrapBlock)entity;
                    return new BootstrapBlockModel() { Id = block.Id, Position = block.Position, Width = block.Width };
                case BlockTypes.Content:
                    ContentBlock content = (ContentBlock)entity;
                    var propertiesDict = PropertyMapper.Map(content.Properties).ToDictionary(x => x.Name, x => x.Value);
                    return new ContentBlockModel() { Id = content.Id, Position = content.Position, PartialViewPath = content.PartialViewPath, Model = new GenericContentModel(propertiesDict) };
                default:
                    return null;
            }
        }

        public static IEnumerable<BlockModel> Map(IEnumerable<Block> entities) => entities.Select(x => BlockMapper.Map(x));
    }
}