using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report
{
    public class View : CommonActionDefinition
    {
        public override string title
        {
            get { return "view"; }
        }

        public override string action_class
        {
            get { return "view-report"; }
        }

        public override string action_name
        {
            get { return "generic-view-report"; }
        }
    }
}