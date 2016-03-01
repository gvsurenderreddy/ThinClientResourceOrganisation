using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions
{
    public class New
                    : CommonActionDefinition
    {
        public override string title
        {
            get { return "new"; }
        }

        public override string action_class
        {
            get { return "new"; }
        }

        public override string action_name
        {
            get { return "new"; }
        }
    }
}