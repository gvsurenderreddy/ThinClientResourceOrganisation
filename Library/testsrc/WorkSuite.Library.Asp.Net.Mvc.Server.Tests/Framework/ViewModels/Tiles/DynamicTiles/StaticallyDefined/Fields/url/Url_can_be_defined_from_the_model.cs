using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.url {

    [TestClass]
    public class Url_can_be_defined_from_the_model {

        // done: from a property of the model via static text
        // done: from a property of the model via a route

        [TestMethod]
        public void from_a_property_of_the_model_via_static_text() {
            model.a_url = "A url";

            definition_builder
                .url( m => m.a_url )
                ;

            tile.url.Should().Be( model.a_url );
        }

        [TestMethod]
        public void from_a_property_of_the_model_via_a_route () {
            model.a_route_id = "A route id";
            helper.route_builder.routes.Add(model.a_route_id, "A route");

            definition_builder
                .url_from_route( m => m.a_route_id, m => new {}  )
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