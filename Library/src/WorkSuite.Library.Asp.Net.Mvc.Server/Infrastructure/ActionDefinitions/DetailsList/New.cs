using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList
{
    public class New : CommonActionDefinition
    {
        public override string title { get { return "new"; } }

        public override string action_class { get { return "new-entry"; } }

        public override string action_name
        {
            get { return "generic-new-entry"; }
        }
    }
}