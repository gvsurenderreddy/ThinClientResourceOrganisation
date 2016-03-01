using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists
{

    public class DetailsListBuilder<S>
    {

        public IsAViewElement build(IEnumerable<S> model)
        {

            return build(model, () => new { });
        }

        // When details list are entities that are owned by a root then we 
        // need to supply a route parameter factory. We can not get it from the 
        // model because the the root may not have any of that type of child.
        public IsAViewElement build
            (IEnumerable<S> model
            , Func<object> route_parameter_factory)
        {

            return new DetailsList
            {
                id = list_metadata.id,
                report_presenter_url = create_report_presenter_url(route_parameter_factory),
                header = create_header(),
                elements = create_elements(model),
                is_sortable = list_metadata.is_sortable

            };
        }

        public DetailsListBuilder
            (IDetailsListMetadataRepository<S> the_list_metadata_repository
            , ActionsBuilder<S> the_actions_builder
            , INamedRouteUrlBuilder the_route_builder
            , ReportBuilder<S> the_report_builder)
        {

            Guard.IsNotNull(the_list_metadata_repository, "the_list_metadata_repository");
            Guard.IsNotNull(the_actions_builder, "the_actions_builder");

            list_metadata_repository = the_list_metadata_repository;
            actions_builder = the_actions_builder;
            report_builder = the_report_builder;

            route_builder = the_route_builder;
        }

        private string create_report_presenter_url(Func<object> route_parameter_factory)
        {
            // create the route parameter factory

            return route_builder.build(new NamedRouteUrlObjectBuildDefinition
            {
                route_name = list_metadata.presenter_id,
                route_parameters_factory = route_parameter_factory,
            });
        }

        private DetailsListHeader create_header()
        {
            return new DetailsListHeader
            {
                title = list_metadata.title,
                actions = create_actions(),
                description = list_metadata.description
            };
        }

        private IEnumerable<IsAViewElement> create_elements(IEnumerable<S> model)
        {
            var report = new List<IsAViewElement>();
            foreach (var report1 in model)
            {
                report.Add(report_builder.build(report1));
            }

            return report;
        }
        private IEnumerable<RoutedAction> create_actions()
        {
            return actions_builder.build();

        }


        private DetailsListMetadata list_metadata
        {
            get
            {
                return list_metadata_repository.metadata_for();
            }
        }
        private readonly IDetailsListMetadataRepository<S> list_metadata_repository;
        private readonly ActionsBuilder<S> actions_builder;

        private readonly ReportBuilder<S> report_builder;
        private INamedRouteUrlBuilder route_builder;

    }

}