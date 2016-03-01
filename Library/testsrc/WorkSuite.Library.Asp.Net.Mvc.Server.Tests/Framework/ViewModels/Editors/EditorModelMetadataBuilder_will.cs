using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Editors {


    [TestClass]
    public class EditorModelMetadataBuilder_will {

        [TestMethod]
        public void implement_IEditorModelMetadataBuilder() {

            builder.Should().BeAssignableTo<IEditorModelMetadataBuilder<AnEditorModel>>();
        }

        [TestMethod]
        public void have_a_default_id_factory () {

            metadata.id.Should().NotBeNull();
        }

        [TestMethod]
        public void set_the_id_factory () {
            // arrange
            Func<AnEditorModel, string> id_factory = m => string.Empty;

            // act
            builder.id( id_factory );

            // assert
            metadata.id.Should().Be( id_factory );
        }

        [TestMethod]
        public void set_the_id_text () {
            var model = new AnEditorModel();
            // act
            builder.id( "Text" );

            // assert
            metadata.id( model ).Should().Be( "Text" );
        }


        [TestMethod]
        public void allow_the_title_to_be_set_as_hardcoded_string () {

            // act
            builder.title( "A title" );
            
            // assert
            metadata.title( model ).Should().Be( "A title" );
        }

        [TestMethod]
        public void allow_the_title_to_be_set_as_a_delegate() {
            

            // act
            builder.title( m => m.Property1 );

            metadata.title( model ).Should().Be( model.Property1 );

        }



        [TestMethod]
        public void set_the_field_id_extension () {
            Func<AnEditorModel, string> factory = m => string.Empty;

            // act
            builder.field_id_extension( factory );

            // assert
            metadata.field_id_extension.Should().Be( factory );
        }      


        [TestInitialize]
        public void test_setup () {
            model = new AnEditorModel();
            repository = new EditorModelMetadataRepository<AnEditorModel>();
            builder = new EditorModelMetadataBuilder<AnEditorModel>( repository );            
        }

        private EditorModelMetadata<AnEditorModel> metadata {
            get { return repository.metadata_for(); }
        }
        private EditorModelMetadataRepository<AnEditorModel> repository;
        private EditorModelMetadataBuilder<AnEditorModel> builder;
        private AnEditorModel model;
    }
}