using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.SectionedTileGrids.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.SectionedTileGrids.StaticallyDefined.Fields.classes {

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

            sectioned_tile_grid.classes.Should().Contain("a class");
        }

        [TestMethod]
        public void can_add_as_an_expression() {
            var a_class = DateTime.Now.Ticks.ToString();

            metadata_builder
                .add_class(() => a_class)
                ;

            sectioned_tile_grid.classes.Should().Contain(a_class);
        }


        [TestMethod]
        public void can_add_multiple_classes() {

            var a_class = DateTime.Now.Ticks.ToString();

            metadata_builder
                .add_class("a class")
                .add_class(() => a_class)
                ;

            sectioned_tile_grid.classes.Should().Contain("a class");
            sectioned_tile_grid.classes.Should().Contain(a_class);
        }

        [TestMethod]
        public void is_an_empty_collection_if_none_specified()
        {

            sectioned_tile_grid.classes.Should().NotBeNull();
            sectioned_tile_grid.classes.Should().BeEmpty();
        }

        [TestInitialize]
        public void before_each_test()
        {
            helper = new StaticSectionedTileGridHelper();
        }

        private StaticSectionedTileGridMetadataBuilder metadata_builder
        {
            get { return helper.metadata_builder; }
        }

        private StaticSectionedTileGridBuilder view_model_builder
        {
            get { return helper.view_model_builder; }
        }

        private SectionedTileGrid sectioned_tile_grid {
            get { return helper.sectioned_tile_grid; }
        }

        private StaticSectionedTileGridHelper helper;
    }
}