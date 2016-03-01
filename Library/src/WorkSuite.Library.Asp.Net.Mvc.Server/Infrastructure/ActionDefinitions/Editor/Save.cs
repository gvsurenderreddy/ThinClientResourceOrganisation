using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor
{
    public class Save : CommonActionDefinition
    {
        public override string title { get { return "Save"; } }

        public override string action_class { get { return "save-edits"; } }

        public override string action_name
        {
            get { return "generic-save-edits"; }
        }
    }
}