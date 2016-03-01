using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor
{
    public sealed class Cancel : CommonActionDefinition
    {
        public override string title { get { return "Cancel"; } }

        public override string action_class { get { return "cancel-edits"; } }

        public override string action_name
        {
            get { return "generic-cancel-edits"; }
        }
    }
}