using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.Repository;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {


    public class EditorActionMetadataRepository<S> 
        : RoutedActionMetadataRepository<S,EditorActionMetadata<S>> 
        , IEditorActionMetadataRepository<S> {}

}