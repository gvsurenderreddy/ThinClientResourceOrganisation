using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report
{
    public class Download : CommonActionDefinition
    {
        public override string title { get { return "download"; } }

        public override string action_class { get { return "download-file"; } }

        public override string action_name
        {
            get { return "generic-download-file"; }
        }
    }
}