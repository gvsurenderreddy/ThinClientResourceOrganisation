using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions
{
    public class SubmitApply
                    : CommonActionDefinition
    {
        public override string title
        {
            get { return "apply"; }
        }

        public override string action_class
        {
            get { return "submit-apply"; }
        }

        public override string action_name
        {
            get { return "submit-apply"; }
        }
    }
}