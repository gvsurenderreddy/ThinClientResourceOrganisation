using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ModelMetadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewElements.Models {

    public class ModelReportBuilder<S> {

        public AViewElement build ( S source ) {

            if (!model_should_be_displayed.decide_for( source )) return new NullViewElement();

            var metadata = model_metadata_repository.metadata_for_model;

            return new ModelReport {
                title = metadata.title,
                report_presenter_url = create_report_presenter_url( source ),
            };
        }

        public ModelReportBuilder 
            ( IPolicy<S> model_should_be_displayed_policy 
            , IModelMetadataRepository<S> the_model_metadata_repository 
            , IRouteBuilder the_route_builder ) {

            Guard.IsNotNull( model_should_be_displayed_policy, "model_should_be_displayed_policy" );
            Guard.IsNotNull( the_model_metadata_repository, "the_model_metadata_repository" );
            Guard.IsNotNull( the_route_builder, "the_route_builder" );

            model_should_be_displayed = model_should_be_displayed_policy;
            model_metadata_repository = the_model_metadata_repository;
            route_builder = the_route_builder;
        }

        // used to decide whether to return a null view element or build a report
        private readonly IPolicy<S> model_should_be_displayed;

        private readonly IModelMetadataRepository<S> model_metadata_repository;


        // creates the url for the models report presenter. i.e. the url
        // that will return the report component representation of this model
        private string create_report_presenter_url ( S model ) {
            // create the route parameter factory
            var metadata = model_metadata_repository.metadata_for_model;

            return route_builder.build( new RouteBuildDefinition {
                route_name = metadata.report_presenter_id,
                route_parameters_factory = () => metadata.report_presenter_route_parameter_factory( model )
            });
        }

        private IRouteBuilder route_builder;

    }

    public interface AViewElement { }

    public class ModelReport : AViewElement {

        public string title { get; set; }
        
        public string report_presenter_url { get; set; }

    }
    public class NullViewElement : AViewElement {}
}