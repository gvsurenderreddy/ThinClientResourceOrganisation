using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Editors;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Reports {


    [TestClass]
    public class ReportModelMetadataBuilder_will {

        [TestMethod]
        public void implement_IReportModelMetadataBuilder() {
            builder.Should().BeAssignableTo<IReportModelMetadataBuilder<AnEditorModel>>();
        }

        [TestMethod]
        public void have_a_default_id () {

            metadata.id.Should().NotBeNull();
        }

        [TestMethod]
        public void set_the_id() {
            // arrange
            Func<AnEditorModel, string> id_factory = m => string.Empty;

            // act
            builder.id( id_factory );

            // assert
            metadata.id.Should().Be( id_factory );
        }

        [TestMethod]
        public void set_the_title_from_a_string () {

            // act
            builder.title( "A title" );

            // assert
            metadata.title( model ).Should().Be( "A title" );
        }

        [TestMethod]
        public void set_the_title_from_a_factory () {
            Func<AnEditorModel, string> factory = m => string.Empty;

            // act
            builder.title( factory );

            // assert
            metadata.title.Should().Be( factory );
        }        

        [TestMethod]
        public void presenter_id () {

            // act
            builder.presenter_id( "A preseneter id" );

            // assert
            metadata.report_presenter_id.Should().Be( "A preseneter id" );
        }

        [TestMethod]
        public void set_the_id_to_the_presenter_id_if_not_already_set () {

            // act
            builder.presenter_id( "A preseneter id" );

            // assert
            metadata.id( model ).Should().Be( "A preseneter id" );
        }       


        // set the field id extension
        [TestMethod]
        public void set_the_field_id_extension () {
            Func<AnEditorModel, string> factory = m => string.Empty;

            // act
            builder.field_id_extension( factory );

            // assert
            metadata.field_id_extension.Should().Be( factory );
        }


        [TestMethod]
        public void set_the_marked_as_hidden_to_false_by_defualt () {

            metadata.is_marked_as_hidden( model ).Should().BeFalse( );            
        }

        [TestMethod]
        public void allows_is_marked_as_hidden_to_be_set_as_an_expression () {
            Func<AnEditorModel, bool> expression = m => false;

            builder.is_marked_as_hidden( expression );

            metadata.is_marked_as_hidden.Should().Be( expression );
        }

        [TestInitialize]
        public void test_setup () {
            model = new AnEditorModel();
            repository = new ReportModelMetadataRepository<AnEditorModel>();
            builder = new ReportModelMetadataBuilder<AnEditorModel>( repository );            
        }

        private ReportModelMetadata<AnEditorModel> metadata {
            get { return repository.metadata_for(); }
        }
        private ReportModelMetadataRepository<AnEditorModel> repository;
        private ReportModelMetadataBuilder<AnEditorModel> builder;
        private AnEditorModel model;
    }
}