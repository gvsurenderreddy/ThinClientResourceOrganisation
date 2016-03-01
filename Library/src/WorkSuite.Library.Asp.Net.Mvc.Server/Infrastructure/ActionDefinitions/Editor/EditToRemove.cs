using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor
{
    /// <summary>
    /// We have two different styles of 'Remove' actions but there is another requirement to have
    ///     a remove action which should display the item to removed in an editor before
    ///     the removal of it; Thus created another 'Remove' action.
    /// </summary>

    public class EditToRemove
                : CommonActionDefinition
    {
        public override string title { get { return "remove"; } }

        public override string action_class { get { return "edit-report"; } }
    }
}