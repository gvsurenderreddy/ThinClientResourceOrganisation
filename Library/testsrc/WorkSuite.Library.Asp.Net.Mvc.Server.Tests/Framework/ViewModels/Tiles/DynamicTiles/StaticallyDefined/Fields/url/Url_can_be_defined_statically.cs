using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.url {

    [TestClass]
    public class Url_can_be_defined_statically {

        // to do: as static text
        // to do: via a route name

        [TestMethod]
        public void as_static_text () {

            definition_builder
                .url( "A Url" )
                ;

            tile.url.Should().Be( "A Url" );
        }

        [TestMethod]
        public void from_a_property_of_the_model_via_a_route() {
            helper.route_builder.routes.Add("A route id", "A route");

            definition_builder
                .url_from_route("A route id", () => new { })
                ;

            tile.url.Should().Be("A route");
        }

 
        [TestInitialize]
        public void before_each_test() {
            helper = new DynamicTileStaticDefinitionHelper<AModel>();
            helper.model = new AModel();

        }

        private DynamicTileStaticDefinitionHelper<AModel> helper;
        private AModel model {
            get { return helper.model; }
        }
        private DynamicTileStaticDefinitionBuilder<AModel> definition_builder {
            get { return helper.definition_builder; }
        }
        private Tile tile {
            get { return helper.tile; }
        }
    }

}