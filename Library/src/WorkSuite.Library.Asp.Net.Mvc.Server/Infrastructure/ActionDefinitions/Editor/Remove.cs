using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor
{
    public sealed class Remove : CommonActionDefinition
    {
        public override string title { get { return "Remove"; } }

        public override string action_class { get { return "save-edits"; } }

        public override string action_name
        {
            get { return "generic-remove-entity"; }
        }
    }
}