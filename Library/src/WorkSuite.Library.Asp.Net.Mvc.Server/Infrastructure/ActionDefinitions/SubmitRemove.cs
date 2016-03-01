using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions
{
    public class SubmitRemove
                    : CommonActionDefinition
    {
        public override string title
        {
            get { return "Remove"; }
        }

        public override string action_class
        {
            get { return "submit-remove"; }
        }

        public override string action_name
        {
            get { return "submit-remove"; }
        }
    }
}