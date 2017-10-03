using CMS.Data.EF;
using CMS.Data.EF.Constants;
using CMS.Data.EF.Entities;
using System;
using System.Collections.Generic;

namespace CMSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestConfiguration();
        }

        private static void RunTestConfiguration()
        {
            var context = new CMSContext();

            var alias = new Alias { LanguageCode = "nl-BE", Url = "Test", Created = DateTime.Now, CreateUser = "Me" };
            var pageType = new PageType { Name = "TextPage", Description = "A page built with the flexible block system", Created = DateTime.Now, CreateUser = "Me" };

            var blockTypeRow = new BlockType { AllowAtRoot = false, Created = DateTime.Now, CreateUser = "Me", Name = BlockTypes.BootstrapRow };
            var blockTypeBlock = new BlockType { AllowAtRoot = false, Created = DateTime.Now, CreateUser = "Me", Name = BlockTypes.BootstrapBlock };
            var blockTypeContent = new BlockType { AllowAtRoot = true, Created = DateTime.Now, CreateUser = "Me", Name = BlockTypes.Content };
            var blockTypeGrid = new BlockType { AllowAtRoot = true, Created = DateTime.Now, CreateUser = "Me", Name = BlockTypes.BootstrapGrid };

            context.BlockTypes.AddRange(new List<BlockType> { blockTypeRow, blockTypeBlock, blockTypeContent, blockTypeGrid });
            context.SaveChanges();

            blockTypeGrid.AddChildTypes(new List<BlockType> { blockTypeRow });
            blockTypeRow.AddChildTypes(new List<BlockType> { blockTypeBlock });
            blockTypeBlock.AddChildTypes(new List<BlockType> { blockTypeRow, blockTypeContent });

            var gridBlock = new Block { Position = 1, Type = blockTypeGrid, Created = DateTime.Now, CreateUser = "Me" };
            var firstRowBlock = new Block { Position = 1, Type = blockTypeRow, Created = DateTime.Now, CreateUser = "Me" };
            var secondRowBlock = new Block { Position = 2, Type = blockTypeRow, Created = DateTime.Now, CreateUser = "Me" };

            gridBlock.AddChild(firstRowBlock);
            gridBlock.AddChild(secondRowBlock);

            var heroImageBlock = new BootstrapBlock { Position = 1, Type = blockTypeBlock, Width = 12, Created = DateTime.Now, CreateUser = "Me" };
            firstRowBlock.AddChild(heroImageBlock);

            var blockOne = new BootstrapBlock { Position = 1, Type = blockTypeBlock, Width = 4, Created = DateTime.Now, CreateUser = "Me" };
            secondRowBlock.AddChild(blockOne);

            var blockTwo = new BootstrapBlock { Position = 2, Type = blockTypeBlock, Width = 8, Created = DateTime.Now, CreateUser = "Me" };
            secondRowBlock.AddChild(blockTwo);

            var heroValueNL = new PropertyValue { Value = "Titel", LanguageCode = "nl-BE", Created = DateTime.Now, CreateUser = "Me" };
            var heroValueEN = new PropertyValue { Value = "Title", LanguageCode = "En-GB", Created = DateTime.Now, CreateUser = "Me" };
            var heroTitle = new Property { Name = "Title", Type = "System.String", Values = new List<PropertyValue> { heroValueNL, heroValueEN }, Created = DateTime.Now, CreateUser = "Me" };

            var heroTextNL = new PropertyValue { Value = "Tekst", LanguageCode = "nl-BE", Created = DateTime.Now, CreateUser = "Me" };
            var heroTextEN = new PropertyValue { Value = "Text", LanguageCode = "En-GB", Created = DateTime.Now, CreateUser = "Me" };
            var heroText = new Property { Name = "Text", Type = "System.String", Values = new List<PropertyValue> { heroTextNL, heroTextEN }, Created = DateTime.Now, CreateUser = "Me" };

            var heroContent = new ContentBlock { Position = 1, Type = blockTypeContent, PartialViewPath = "~/Views/Partials/Grid/HeroImage.cshtml", Properties = new List<Property> { heroTitle, heroText } , Created = DateTime.Now, CreateUser = "Me" };
            heroImageBlock.AddChild(heroContent);

            var contentBlockOne = new ContentBlock { Position = 1, Type = blockTypeContent, PartialViewPath = "~/Views/Partials/Grid/_Test.cshtml", Properties = null, Created = DateTime.Now, CreateUser = "Me" };
            blockOne.AddChild(contentBlockOne);

            var contentBlockTwo = new ContentBlock { Position = 1, Type = blockTypeContent, PartialViewPath = "~/Views/Partials/Grid/_Test.cshtml", Properties = null, Created = DateTime.Now, CreateUser = "Me" };
            blockTwo.AddChild(contentBlockTwo);

            var blocks = new List<Block>
            {
                gridBlock,
                firstRowBlock,
                secondRowBlock,
                blockOne,
                blockTwo,
                contentBlockOne,
                contentBlockTwo
            };

            var page = new Page { Name = "TestPage", Aliases = new List<Alias> { alias }, IsPublished = true, Created = DateTime.Now, CreateUser = "Me", Type = pageType, Blocks = blocks };

            context.Pages.Add(page);
            context.SaveChanges();
        }
    }
}