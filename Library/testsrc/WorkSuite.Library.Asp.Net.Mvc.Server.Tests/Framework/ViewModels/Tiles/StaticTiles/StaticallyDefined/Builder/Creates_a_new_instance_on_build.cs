using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Builder {

    [TestClass]
    public class Creates_a_new_instance_on_build {

        // done: id
        // done: url
        // done: title
        // done: classes

        [TestMethod]
        public void changing_the_id_does_not_affect_previously_build_metdata () {

            model_metadata_builder
                .id( "one" )
                ;

            var first = model_metadata_builder.build();

            model_metadata_builder
                .id( "two " )
                ;

            first.id().Should().Be( "one" );
        }

        [TestMethod]
        public void changing_the_url_does_not_affect_previously_build_metdata () {

            model_metadata_builder
                .url("one")
                ;

            var first = model_metadata_builder.build();

            model_metadata_builder
                .url("two ")
                ;

            first.url().Should().Be("one");
        }

        [TestMethod]
        public void changing_the_title_does_not_affect_previously_build_metdata () {

            model_metadata_builder
                .title("one")
                ;

            var first = model_metadata_builder.build();

            model_metadata_builder
                .title("two ")
                ;

            first.title().Should().Be("one");
        }

        [TestMethod]
        public void adding_a_class_does_not_affect_previously_build_metdata() {

            model_metadata_builder
                .add_class("one")
                ;

            var first = model_metadata_builder.build();

            model_metadata_builder
                .add_class("two ")
                ;

            first.classes.Select( ce => ce() ).Should().NotContain( "two" );
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