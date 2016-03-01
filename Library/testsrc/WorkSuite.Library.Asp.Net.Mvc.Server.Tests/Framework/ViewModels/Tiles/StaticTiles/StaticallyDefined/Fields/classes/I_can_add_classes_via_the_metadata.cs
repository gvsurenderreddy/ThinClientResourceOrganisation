using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Fields.classes {

    [TestClass]
    public class I_can_add_classes_via_the_metadata {

        // done: can add as a string
        // done: can add as an expression
        // done: can add multiple classes
        // to do: is an empty collection if none specified

        [TestMethod]
        public void can_add_as_a_string () {
            model_metadata_builder
                .add_class( "a class" )
                ;

            tile.classes.Should().Contain( "a class" );
        }

        [TestMethod]
        public void can_add_as_an_expression () {
            var a_class = DateTime.Now.Ticks.ToString();

            model_metadata_builder
                .add_class( () => a_class )
                ;

            tile.classes.Should().Contain( a_class );
        }


        [TestMethod]
        public void can_add_multiple_classes () {
            var a_class = DateTime.Now.Ticks.ToString();

            model_metadata_builder
                .add_class( "a class" )
                .add_class( () => a_class )
                ;

            tile.classes.Should().Contain( "a class" );
            tile.classes.Should().Contain( a_class );
        }

        [TestMethod]
        public void is_an_empty_collection_if_none_specified () {

            tile.classes.Should().NotBeNull();
            tile.classes.Should().BeEmpty();
        }

        [TestInitialize]
        public void before_each_test()
        {
            helper = new StaticTileHelper();
        }



        private StaticTileStaticDefinitionBuilder model_metadata_builder
        {
            get { return helper.model_metadata_builder; }
        }

        private Tile tile
        {
            get { return helper.tile; }
        }

        private StaticTileHelper helper;
    }
}