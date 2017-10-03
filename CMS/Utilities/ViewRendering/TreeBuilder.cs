using CMS.Data.EF.Entities;
using CMS.Models.CMS;
using CMS.Utilities.Mapping;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Utilities.ViewRendering
{
    public static class TreeBuilder
    {
        public static List<BlockModel> BuildBlockTree(IList<Block> pageBlocks)
        {
            var rootEntities = pageBlocks.Where(x => x.ParentBlock == null);
            Dictionary<Guid, BlockModel> models = BlockMapper.Map(rootEntities).ToDictionary(x => x.Id, x => x);

            var mappingQueue = new Queue<Tuple<BlockModel, Block>>();
            foreach (var rootEntity in rootEntities)
            {
                foreach (var child in rootEntity.ChildBlocks)
                {
                    mappingQueue.Enqueue(Tuple.Create(models[rootEntity.Id], child));
                }
            }

            //Breadth First Search mapping
            while (mappingQueue.Any())
            {
                var nextUp = mappingQueue.Dequeue();

                var parentModel = nextUp.Item1;
                var childEntity = nextUp.Item2;
                var childModel = BlockMapper.Map(nextUp.Item2);

                models.Add(childModel.Id, childModel); //add these so we can do lookup later

                //Set relations
                parentModel.Children.Add(childModel);
                childModel.Parent = parentModel;

                //Add children to queue if needed
                if (childEntity.ChildBlocks != null && childEntity.ChildBlocks.Any())
                {
                    foreach (var child in childEntity.ChildBlocks)
                    {
                        mappingQueue.Enqueue(Tuple.Create(childModel, child));
                    }
                }
            }

            return models.Values.Where(x => x.Parent == null).ToList();
        }
    }
}