using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Actions {

    public class ActionsBuilder<S>
        : RoutedActionBuilder<IDetailsListActionMetadataRepository<S>,DetailsListActionMetadata<S>,S>{

        public ActionsBuilder 
                  ( IDetailsListActionMetadataRepository<S> the_repository
                  , INamedRouteUrlBuilder the_route_builder) 
             : base
                  ( the_repository
                  , the_route_builder ) {}
    }
}