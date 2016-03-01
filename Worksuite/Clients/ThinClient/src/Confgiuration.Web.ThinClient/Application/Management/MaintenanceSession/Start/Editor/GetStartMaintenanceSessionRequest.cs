using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Request {

    public class GetStartMaintenanceSessionRequest
                    : CommonActionDefinition {

        public override string title { get { return "Start maintenance session"; }}

        public override string classification { get { return "edit-report"; } }
    }
}