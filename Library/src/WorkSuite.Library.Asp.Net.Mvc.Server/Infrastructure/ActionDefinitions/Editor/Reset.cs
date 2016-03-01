using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor
{
    public sealed class Reset : CommonActionDefinition
    {

        public override string title { get { return "Reset to default"; } }

        public override string action_class { get { return "reset-edits"; } }
    }
}