using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions
{
    public class View
                    : CommonActionDefinition
    {
        public override string title
        {
            get { return "view"; }
        }

        public override string action_class
        {
            get { return "view"; }
        }

        public override string action_name
        {
            get { return "view"; }
        }
    }
}