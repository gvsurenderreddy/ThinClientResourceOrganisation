using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports
{

    public class ReportBuilder<S>
    {

        public IsAViewElement build(S source)
        {

            // to do: if (!report_should_be_displayed.decide_for( source )) return new NullViewElement();

            var model_metadata = model_metadata_repository.metadata_for();
            var check_discription = (model_metadata.should_display_discription == null) || model_metadata.should_display_discription(source);
            return new Report
            {
                id = model_metadata.id(source),
                title = model_metadata.title(source),
                description = (check_discription == false) ? model_metadata.description : string.Empty,
                actions = create_report_actions(source),
                fields = report_fields_builder.build(source),
                is_marked_as_hidden = model_metadata.is_marked_as_hidden(source)
            };
        }

        public ReportBuilder
            (IReportModelMetadataRepository<S> the_model_metadata_repository
            , INamedRouteUrlBuilder the_route_builder
            , ReportFieldsBuilder<S> the_report_fields_builder
            , ActionsBuilder<S> the_actions_builder)
        {

            Guard.IsNotNull(the_model_metadata_repository, "the_model_metadata_repository");
            Guard.IsNotNull(the_route_builder, "the_route_builder");
            Guard.IsNotNull(the_report_fields_builder, "the_report_fields_builder");
            Guard.IsNotNull(the_actions_builder, "the_actions_builder");

            model_metadata_repository = the_model_metadata_repository;
            route_builder = the_route_builder;
            report_fields_builder = the_report_fields_builder;
            actions_builder = the_actions_builder;
        }


        // creates the collection of actions for the report
        private IEnumerable<RoutedAction> create_report_actions(S model)
        {

            return actions_builder.build(model);
        }

        // used to get model metadata for the repository.
        private readonly IReportModelMetadataRepository<S> model_metadata_repository;

        // used to get routes for the presenter and actions
        private readonly INamedRouteUrlBuilder route_builder;

        // used to build the fields from the model
        private readonly ReportFieldsBuilder<S> report_fields_builder;

        // used to builde the routed actions for the report
        private readonly ActionsBuilder<S> actions_builder;

    }
}