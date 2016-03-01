using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Fields.Fields.Title {

    [TestClass]
    public class Title_can_be_defined_statically {
        
        // done: as static text
        // done: from an expression

        [TestMethod]
        public void as_static_text() {

            fields_definition_builder
                .add_field_from_propertry(m => m.a_property)
                .title("A title")
                ;

            tile.fields.First( f => f.name == "a_property" ).title.Should().Be( "A title" );
        }

        [TestMethod]
        public void from_an_expression() {
            var title = DateTime.Now.Ticks.ToString();

            fields_definition_builder
                .add_field_from_propertry(m => m.a_property)
                .title(() => title)
                ;

            tile.fields.First( f => f.name == "a_property" ).title.Should().Be(title);
        }

        [TestMethod]
        public void is_an_empty_string_if_not_defined() {

            fields_definition_builder
                .add_field_from_propertry(m => m.a_property)
                ;

            tile.fields.First(f => f.name == "a_property").title.Should().BeEmpty(  );
        }


        [TestInitialize]
        public void before_each_test() {
            helper = new DynamicTileStaticDefinitionHelper<AModel>();
            helper.model = new AModel();
        }

        private DynamicTileStaticDefinitionHelper<AModel> helper;
        private DynamicTileFieldsStaticDefinitionBuilder<AModel> fields_definition_builder
        {
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