using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.TileGrids.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.TileGrids.StaticallyDefined.Fields.classes {

    [TestClass]
    public class I_can_add_classes_via_the_metadata {

        // done: can add as a string
        // done: can add as an expression
        // done: can add multiple classes

        [TestMethod]
        public void can_add_as_a_string () {

            metadata_builder
                .add_class( "a class" )
                ;

            tile_grid.classes.Should().Contain("a class");
        }

        [TestMethod]
        public void can_add_as_an_expression()
        {
            var a_class = DateTime.Now.Ticks.ToString();

            metadata_builder
                .add_class(() => a_class)
                ;

            tile_grid.classes.Should().Contain(a_class);
        }


        [TestMethod]
        public void can_add_multiple_classes()
        {

            var a_class = DateTime.Now.Ticks.ToString();

            metadata_builder
                .add_class("a class")
                .add_class(() => a_class)
                ;

            tile_grid.classes.Should().Contain("a class");
            tile_grid.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void is_an_empty_collection_if_none_specified()
        {

            tile_grid.classes.Should().NotBeNull();
            tile_grid.classes.Should().BeEmpty();
        }


        [TestInitialize]
        public void before_each_test()
        {
            helper = new StaticTileGridHelper();
        }

        private StaticTileGridMetadataBuilder metadata_builder
        {
            get { return helper.metadata_builder; }
        }

        private TileGrid tile_grid
        {
            get { return helper.tile_grid; }
        }

        private StaticTileGridHelper helper;

    }
}