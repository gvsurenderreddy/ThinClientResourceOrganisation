using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Editors {

    [TestClass]
    public class EditorFieldMetadataRepository_will {

        // done: return a default metadata if the metadata for a property has not been defined  
        // done: default field to excluded if the metadata for a property has not been defined 
        // done: return the defined metadata for a property


        [TestMethod]
        public void return_a_default_metadata_if_the_metadata_for_a_property_has_not_been_defined () {

            repository.metadata_for( property ).Should().NotBeNull();
        }

        [TestMethod]
        public void default_field_to_excluded_if_the_metadata_for_a_property_has_not_been_defined () {


            repository.metadata_for( property ).status.Should().Be( EditorFieldStatus.excluded );
        }


        [TestMethod]
        public void return_the_defined_metadata_for_a_property () {
            var metadata = new EditorFieldMetadata<AnEditorModel>();

            repository.add_metadata( property.Name, metadata );

            repository.metadata_for( property ).Should().Be( metadata );
        }

        [TestInitialize]
        public void test_setup () {
            property = typeof( AnEditorModel )
                                .GetProperties()
                                .Single( p => p.Name == "Property1" )
                                ;

            repository = new EditorFieldMetadataRepository<AnEditorModel>();
        }

        private PropertyInfo property;
        private EditorFieldMetadataRepository<AnEditorModel> repository;

    }

}