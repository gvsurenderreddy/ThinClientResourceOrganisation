namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States {

   /// <summary>
    ///     Status returned when there is a currently active maintenance session
    /// </summary>
    public class InMaintenanceSession
                    : AMaintenanceSesssionStatus {

       public override MaintenanceSessionState state {
           get { return MaintenanceSessionState.active; }
       }
   }
}