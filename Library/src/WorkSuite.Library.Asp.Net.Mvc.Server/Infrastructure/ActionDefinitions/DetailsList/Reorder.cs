using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList
{
    public class Reorder : CommonActionDefinition
    {
        public override string title { get { return "reorder"; } }

        public override string action_class { get { return "reorder-report"; } }

        public override string action_name
        {
            get { return "generic-reorder-entity"; }
        }
    }
}