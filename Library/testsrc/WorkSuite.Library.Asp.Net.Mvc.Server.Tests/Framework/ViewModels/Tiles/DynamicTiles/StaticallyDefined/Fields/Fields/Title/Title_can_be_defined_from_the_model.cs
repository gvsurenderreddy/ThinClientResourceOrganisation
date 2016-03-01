using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.Fields.Title {

    [TestClass]
    public class Title_can_be_defined_from_the_model {

        // done: from the a property of the model

        [TestMethod]
        public void from_the_a_property_of_the_model() {
            model.a_title = "A title";

            fields_definition_builder
                .add_field_from_propertry(m => m.a_property)
                .title( m => m.a_title )
                ;

            tile.fields.First( f => f.name == "a_property" ).title.Should().Be( model.a_title );
        }


        [TestInitialize]
        public void before_each_test() {
            helper = new DynamicTileStaticDefinitionHelper<AModel>();
            helper.model = new AModel();
        }

        private DynamicTileStaticDefinitionHelper<AModel> helper;
        private DynamicTileFieldsStaticDefinitionBuilder<AModel> fields_definition_builder {
            get { return helper.fields_definition_builder; }
        }
        private AModel model {
            get { return helper.model; }
        }
        private Tile tile {
            get { return helper.tile; }
        }
    }

}