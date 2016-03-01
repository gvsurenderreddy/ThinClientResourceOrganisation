using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder {

    [TestClass]
    public class Allows_multiple_sections_to_be_added {

        // done: can add multiple sections
        // done: sections are order in the order they are added

        [TestMethod]
        public void sections_are_order_in_the_order_they_are_added () {

            metadata_builder
                .new_section( "first section" )
                .add()
                ;

            metadata_builder
                .new_section("second section")
                .add()
                ;


            var metadata = metadata_builder.build();
            var view_model = view_model_builder.build( metadata );

            view_model.sections.First().title.Should().Be( "first section" );
            view_model.sections.Skip(1).First().title.Should().Be("second section");
        }

        [TestInitialize]
        public void before_each_test()
        {
            metadata_builder = new StaticSectionedTileGridMetadataBuilder();
            view_model_builder = new StaticSectionedTileGridBuilder();
        }

        private StaticSectionedTileGridMetadataBuilder metadata_builder;
        private StaticSectionedTileGridBuilder view_model_builder;

    }
}