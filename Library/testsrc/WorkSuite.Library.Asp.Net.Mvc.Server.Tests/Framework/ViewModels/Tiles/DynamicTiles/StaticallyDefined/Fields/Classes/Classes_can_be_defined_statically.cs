using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.Classes {

    [TestClass]
    public class Classes_can_be_defined_statically {

        [TestMethod]
        public void can_add_as_a_string() {

            definition_builder
                .add_class( "a class" )
                ;

            tile.classes.Should().Contain("a class");
        }

        [TestMethod]
        public void can_add_as_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            definition_builder
                .add_class(() => a_class)
                ;

            tile.classes.Should().Contain(a_class);
        }


        [TestMethod]
        public void can_add_multiple_classes()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            definition_builder
                .add_class("a class")
                .add_class(() => a_class)
                ;

            tile.classes.Should().Contain("a class");
            tile.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void is_an_empty_collection_if_none_specified()
        {

            tile.classes.Should().NotBeNull();
            tile.classes.Should().BeEmpty();
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