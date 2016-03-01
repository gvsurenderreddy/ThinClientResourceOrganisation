using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions
{
    public class ToggleWeek : CommonActionDefinition
    {
        public override string title
        {
            get { return "Week"; }
        }

        public override string action_class
        {
            get { return "Palette-DateRange-Toggle-Week"; }
        }

        public override string action_name
        {
            get { return "toggle-week"; }
        }
    }
}
