using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.End.Editor {

    /// <summary>
    ///     Definition for the action that will execute the end maintenance session command
    /// </summary>
    public class EndMaintenanceSessionAction 
                    : Save {

        public override string title {
            get { return "End maintenance session"; }
        }
    }
}