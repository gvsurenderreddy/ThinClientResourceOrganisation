using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions {
    
    /// <summary>
    ///     Builder that allows you to define the actions 
    /// that are to appear on a specific editor.
    /// </summary>
    public interface IDetailsListActionsMetadataBuilder<S>
        : IRoutedActionsMetadataBuilder<S,IDetailsListActionMetadataBuilder<S>>{}   
}