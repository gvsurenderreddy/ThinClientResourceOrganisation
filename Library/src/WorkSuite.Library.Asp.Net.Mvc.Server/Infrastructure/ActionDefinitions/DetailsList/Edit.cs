using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList
{
    public class Edit : CommonActionDefinition
    {
        public override string title { get { return "edit"; } }

        public override string action_class { get { return "edit-list"; } }

        public override string action_name
        {
            get { return "generic-edit-list"; }
        }
    }
}