using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Editors {


    [TestClass]
    public class EditorFieldMetadataBuilder_will {
         
        // done: add the metadata to the repository
        // done: default the status to editable
        // done: allow the status to be set to hidden

        [TestMethod]
        public void add_the_metadata_to_the_repository () {
            metadata.Should().NotBeNull();
        }


        [TestMethod]
        public void default_the_status_to_editable () {

            metadata.status.Should().Be( EditorFieldStatus.editable );
        }

        [TestMethod]
        public void allow_the_status_to_be_set_to_hidden () {

            builder
                .is_hidden()
                ;

            metadata.status.Should().Be( EditorFieldStatus.hidden );
        }

        [TestMethod]
        public void defaults_the_field_type_to_not_specified ( ) {

            metadata.field_type.Should(  ).Be( FieldTypes.NotSpecified );
            
        }


        [TestMethod]
        public void allows_a_field_to_be_set_as_a_look_up_field ( ) {
            
            builder
                .is_lookup ()
                ;

            metadata.field_type.Should(  ).Be(  FieldTypes.Lookup );
        }

        [TestMethod]
        public void allows_help_to_be_set_for_a_field ( ) {
            
            builder
                .help ( "Some help" )
                ;

            metadata.help.Should().Be( "Some help" );
        }


        [TestInitialize]
        public void test_setup () {
            metadata = null;
            builder = new EditorFieldMetadataBuilder<AnEditorModel>( m => metadata = m );            
        }

        private EditorFieldMetadata<AnEditorModel> metadata = null;
        private EditorFieldMetadataBuilder<AnEditorModel> builder;
    }
}