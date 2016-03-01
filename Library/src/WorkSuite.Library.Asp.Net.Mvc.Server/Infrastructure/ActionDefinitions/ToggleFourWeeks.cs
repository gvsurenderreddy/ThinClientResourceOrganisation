using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions
{
    public class ToggleFourWeeks : CommonActionDefinition
    {
        public override string title
        {
            get { return "4 weeks"; }
        }

        public override string action_class
        {
            get { return "Palette-DateRange-Toggle-FourWeeks"; }
        }

        public override string action_name
        {
            get { return "toggle-four-weeks"; }
        }
    }
}
