using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ModelMetadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewElements.Models;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewElement.Models {


    [TestClass]
    public class ModelReportBuilder_will {

        // done: return an a report view element
        // done: return a null view element if not allowed to view the element
        // to do: set the report's id from the model metadata
        // done: set the report's title from the model metadata 
        // done: set the models report presenter url from the metadata and model
        // to do: add the actions to the report (needs more definition)
        // to do: add the fields to the report (needs more definition) 

        [TestMethod]
        public void return_an_a_report_view_element () {

            builder.build( model ).Should(  ).BeOfType<ModelReport>();
        }


        [TestMethod]
        public void return_a_null_view_element_if_not_allowed_to_view_the_model () {
            is_allowed_to_view_model = false;

            builder.build( model ).Should().BeOfType<NullViewElement>();
        }


        [TestMethod]
        public void set_the_report_id_from_the_model_metadata () {

            builder.build( model ).As<ModelReport>().title.Should().Be( metadata.title );
        }

        [TestMethod]
        public void set_the_models_report_presenter_url_from_the_metadata_and_model () {
            
            builder.build( model ).As<ModelReport>().report_presenter_url.Should().Be( the_report_presenter_url );
        }

        [TestInitialize]
        public void before_each_test () {
            model = new AReportModel();

            metadata = new AReportModelMetadata {
                title = "The title",
                report_presenter_route_parameter_factory = m => new {},
            };

            metadata_repository = MockRepository.GenerateStub<IModelMetadataRepository<AReportModel>>();
            metadata_repository
                .Stub( r => r.metadata_for_model )
                .Return( metadata )
                ;

            visibility_policy = MockRepository.GenerateStub<IPolicy<AReportModel>>();
            visibility_policy
                .Stub( p => p.decide_for( model ))
                .Do( (Func<AReportModel,bool>)( s => is_allowed_to_view_model ))
                ;
            
            is_allowed_to_view_model = true;

            the_report_presenter_url = "The report presenter url";


            route_builder = MockRepository.GenerateStub<IRouteBuilder>(  );
            route_builder
                .Stub( rb => rb.build( null ) )
                .IgnoreArguments(  )
                .Return( the_report_presenter_url  )
                ;


            builder = new ModelReportBuilder<AReportModel>
                            ( visibility_policy 
                            , metadata_repository 
                            , route_builder );
        }

        private AReportModel model;
        private AReportModelMetadata metadata;
        private IModelMetadataRepository<AReportModel> metadata_repository;
        private IPolicy<AReportModel> visibility_policy;
        private bool is_allowed_to_view_model;
        private string the_report_presenter_url;
        private ModelReportBuilder<AReportModel> builder;
        private IRouteBuilder route_builder;

    }

    public class AReportModel { }

    public class AReportModelMetadata : ModelMetadata<AReportModel> {}
}