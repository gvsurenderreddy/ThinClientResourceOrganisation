using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {
    
    /// <summary>
    ///     Builder that allows you to define the actions 
    /// that are to appear on a specific editor.
    /// </summary>
    public interface IEditorActionsMetadataBuilder<S>
        : IRoutedActionsMetadataBuilder<S,IEditorActionMetadataBuilder<S>>{}   
}