using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder
{
    // to do: (UJ87 - WPM) rename to UserActionsMetatadataBuilder
    //                     it is in here that we will add the multiple outcome action

    public abstract class RoutedActionsMetadataBuilder<S, B>
              : IRoutedActionsMetadataBuilder<S, B>
      where B : IRoutedActionMetadataBuilder<S, B>
    {
        public B add_action<C>()
            where C : CommonActionDefinition, new()
        {
            var common_properties = new C();
            var result = create_action_builder();

            result.action_class(common_properties.action_class);
            result.action_name(common_properties.action_name);
            result.title(common_properties.title);

            return result;            
        }

        protected abstract B create_action_builder();
    }
}