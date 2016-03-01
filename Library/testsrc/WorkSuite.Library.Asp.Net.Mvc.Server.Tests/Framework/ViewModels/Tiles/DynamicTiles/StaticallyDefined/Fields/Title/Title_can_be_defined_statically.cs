using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.Title {

    [TestClass]
    public class Title_can_be_defined_statically {
        
        // done: as static text
        // done: from an expression

        [TestMethod]
        public void as_static_text() {

            definition_builder
                .title("A title")
                ;

            tile.title.Should().Be("A title");
        }



        [TestMethod]
        public void from_an_expression () {
            var title = DateTime.Now.Ticks.ToString();

            definition_builder
                .title(() => title)
                ;

            tile.title.Should().Be(title);
        }

        [TestMethod]
        public void is_an_empty_string_if_not_defined() {

            tile.title.Should().BeEmpty();
        }


        [TestInitialize]
        public void before_each_test()
        {
            helper = new DynamicTileStaticDefinitionHelper<AModel>();
            helper.model = new AModel();

        }

        private DynamicTileStaticDefinitionHelper<AModel> helper;
        private AModel model
        {
            get { return helper.model; }
        }
        private DynamicTileStaticDefinitionBuilder<AModel> definition_builder
        {
            get { return helper.definition_builder; }
        }
        private Tile tile
        {
            get { return helper.tile; }
        }

    }

}