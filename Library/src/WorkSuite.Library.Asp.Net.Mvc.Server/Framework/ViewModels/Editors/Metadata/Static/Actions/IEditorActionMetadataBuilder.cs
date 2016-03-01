using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    /// <summary>
    ///     Builder that allows you to define 
    /// </summary>
     public interface IEditorActionMetadataBuilder<S> 
         : IRoutedActionMetadataBuilder<S, IEditorActionMetadataBuilder<S>> {}
}