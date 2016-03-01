using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.Fields {

    [TestClass]
    public class Fields_can_be_added_for_properties_of_the_model {

        // done: public properties can be added

        [TestMethod]
        public void public_properties_can_be_added() {
            fields_definition_builder
                .add_field_from_propertry( m => m.a_property )
                ;

            tile.fields.Should().Contain(f => f.name == "a_property");
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
        private AModel model
        {
            get { return helper.model; }
        }
        private Tile tile
        {
            get { return helper.tile; }
        }

    }

}