using CMS.Data.EF;
using CMS.Data.EF.Entities;
using System;
using CMS.Data.EF.Constants;
using System.Collections.Generic;

namespace CMSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CMSContext();

            var alias = new Alias { LanguageCode = "nl-BE", Url = "Test", Created = DateTime.Now, CreateUser = "Me" };
            var pageType = new PageType { Description = "TextPage", Created = DateTime.Now, CreateUser = "Me" };

            var gridBlock = new Block { Position = 1, Type = BlockType.BootstrapGrid, Created = DateTime.Now, CreateUser = "Me" };
            var rowBlock = new Block { Position = 1, Type = BlockType.BootstrapRow, Created = DateTime.Now, CreateUser = "Me" };

            //TODO: Dont let them add children to the list -> Create methods AddChild, RemoveChild that sets parent node!
            gridBlock.ChildBlocks.Add(rowBlock);

            var blockOne = new BootstrapBlock { Position = 1, Type = BlockType.BootstrapBlock, Width = 4, Created = DateTime.Now, CreateUser = "Me" };
            rowBlock.ChildBlocks.Add(blockOne);

            var blockTwo = new BootstrapBlock { Position = 2, Type = BlockType.BootstrapBlock, Width = 8, Created = DateTime.Now, CreateUser = "Me" };
            rowBlock.ChildBlocks.Add(blockTwo);

            var contentBlockOne = new ContentBlock { Position = 1, Type = BlockType.Content, PartialViewPath = "~/Views/Partial/Grid/_Test.cshtml", Properties = null, Created = DateTime.Now, CreateUser = "Me" };
            blockOne.ChildBlocks.Add(contentBlockOne);

            var contentBlockTwo = new ContentBlock { Position = 1, Type = BlockType.Content, PartialViewPath = "~/Views/Partial/Grid/_Test.cshtml", Properties = null, Created = DateTime.Now, CreateUser = "Me" };
            blockTwo.ChildBlocks.Add(contentBlockTwo);

            var blocks = new List<Block>();
            blocks.Add(gridBlock);
            blocks.Add(rowBlock);
            blocks.Add(blockOne);
            blocks.Add(blockTwo);
            blocks.Add(contentBlockOne);
            blocks.Add(contentBlockTwo);

            var page = new Page { Name = "TestPage", Aliases = new List<Alias> { alias }, Created = DateTime.Now, CreateUser = "Me", Type = pageType, Blocks = blocks };

            context.Pages.Add(page);
            context.SaveChanges();
        }
    }
}