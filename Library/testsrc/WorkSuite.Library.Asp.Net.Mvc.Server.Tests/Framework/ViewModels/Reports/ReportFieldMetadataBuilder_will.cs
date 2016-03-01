using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Editors;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Reports {


    [TestClass]
    public class ReportFieldMetadataBuilder_will {
         

        [TestMethod]
        public void add_the_metadata_to_the_repository () {
            metadata.Should().NotBeNull();
        }

        [TestMethod]
        public void set_the_id () {
            builder.id( "An Id" );

            metadata.id(model).Should().Be("An Id");
        }

        [TestMethod]
        public void set_the_label () {
            builder.id( "An label" );
          
            metadata.id(model).Should().Be("An label");
        }


        [TestMethod]
        public void set_is_included ()
        {
            Func<AnEditorModel, bool> resolution = m => false;

            builder.is_included( resolution );

            metadata.is_included.Should().Be(resolution);
        }

        [TestMethod]
        public void default_is_included_to_true()
        {
            var model = new AnEditorModel();

            metadata.is_included( model ).Should().BeTrue();

        }

        [TestMethod]
        public void default_humanize_to_false () {

            metadata.humanize.Should().BeFalse();
        }

        [TestMethod]
        public void calling_humanize_on_the_builder_set_humanize_on_the_metadata_to_true () {

            builder.humanize();

            metadata.humanize.Should().BeTrue();
        }

        [TestMethod]
        public void default_report_field_type_should_be_undefined()
        {
            metadata.field_type.Should().Be(FieldTypes.Undefined);
        }

        [TestMethod]
        public void calling_is_simple_image_on_the_builder_should_set_metadatas_field_type_to_simple_image()
        {
            builder.is_simple_image();
            metadata.field_type.Should().Be(FieldTypes.SimpleImage);
        }


        [TestInitialize]
        public void test_setup () {
            metadata = null;
            builder = new ReportFieldMetadataBuilder<AnEditorModel>( m => metadata = m );            
            model = new AnEditorModel();
        }

        private ReportFieldMetadata<AnEditorModel> metadata = null;
        private ReportFieldMetadataBuilder<AnEditorModel> builder;
        private AnEditorModel model;

    }
}