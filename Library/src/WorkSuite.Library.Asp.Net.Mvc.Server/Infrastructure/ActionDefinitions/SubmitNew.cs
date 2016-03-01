using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions
{
    public class SubmitNew
                    : CommonActionDefinition
    {
        public override string title
        {
            get { return "Save"; }
        }

        public override string action_class
        {
            get { return "submit-new"; }
        }

        public override string action_name
        {
            get { return "submit-new"; }
        }
    }
}