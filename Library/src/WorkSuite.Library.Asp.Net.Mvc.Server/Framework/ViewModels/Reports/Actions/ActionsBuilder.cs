using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Actions {

    public class ActionsBuilder<S>
        : RoutedActionBuilder<IReportActionMetadataRepository<S>,ReportActionMetadata<S>,S>{

        public ActionsBuilder 
                  ( IReportActionMetadataRepository<S> the_repository
                  , INamedRouteUrlBuilder the_route_builder) 
             : base
                  ( the_repository
                  , the_route_builder ) {}
    }
}