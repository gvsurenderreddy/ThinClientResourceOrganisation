using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Entity
{
    public class Remove : CommonActionDefinition
    {
        public override string title { get { return "remove"; } }

        public override string action_class { get { return "remove-entity"; } }

        public override string action_name
        {
            get { return "generic-remove-entity_another"; }
        }
    }
}