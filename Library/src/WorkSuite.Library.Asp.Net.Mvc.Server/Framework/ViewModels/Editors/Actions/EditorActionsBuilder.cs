using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Actions {

  
    public class EditorActionsBuilder<S>
        : RoutedActionBuilder<IEditorActionMetadataRepository<S>,EditorActionMetadata<S>,S>{

        public EditorActionsBuilder 
                  ( IEditorActionMetadataRepository<S> the_repository
                  , INamedRouteUrlBuilder the_route_builder) 
             : base
                  ( the_repository
                  , the_route_builder ) {}
    }
}