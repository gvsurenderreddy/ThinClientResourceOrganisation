using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Configuration {
    
    /// <summary>
    ///     Builder that allows you to define the actions 
    /// that are to appear on a specific editor.
    /// </summary>
    public interface IEditorActionsMetadataBuilder<S> {

        /// <summary>
        ///     Returns action builder with action    
        /// </summary>
        /// <typeparam name="C">
        ///     The common action type to build the definition is from
        /// </typeparam>
        /// <returns>
        ///     Builder that allows you to create
        /// </returns>
        IEditorActionMetadataBuilder<S> add_action<C> () where C : CommonActionDefinition, new();

    }
}