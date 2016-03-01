using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder {

    // to do: (UJ87 - WPM) rename to IsAUserActionsMetatadataBuilder 

    public interface IRoutedActionsMetadataBuilder<S,B> 
        where B : IRoutedActionMetadataBuilder<S, B>   {

        /// <summary>
        ///     Returns action builder with action    
        /// </summary>
        /// <typeparam name="C">
        ///     The common action type to build the definition is from
        /// </typeparam>
        /// <returns>
        ///     Builder that allows you to create
        /// </returns>
        B add_action<C> () where C : CommonActionDefinition, new();
    }
}