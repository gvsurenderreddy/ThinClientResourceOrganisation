using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.Title {

    [TestClass]
    public class Title_can_be_defined_from_the_model {

        // done: from the a property of the model

        [TestMethod]
        public void from_the_a_property_of_the_model() {
            model.a_title = "A title";

            definition_builder
                .title(m => m.a_title)
                ;

            tile.title.Should().Be( model.a_title );
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