using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.Repository;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions {


    public class DetailsListActionMetadataRepository<S> 
        : RoutedActionMetadataRepository<S,DetailsListActionMetadata<S>> 
        , IDetailsListActionMetadataRepository<S> {}

}