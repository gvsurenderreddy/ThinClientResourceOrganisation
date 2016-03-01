namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States {

    /// <summary>
    ///     Status returned when there is not a currently active maintenance session.
    /// </summary>
    public class NotInMaintenanceSession
                    : AMaintenanceSesssionStatus {

        public override MaintenanceSessionState state {

            get { return MaintenanceSessionState.not_active; }
        }
    }
}