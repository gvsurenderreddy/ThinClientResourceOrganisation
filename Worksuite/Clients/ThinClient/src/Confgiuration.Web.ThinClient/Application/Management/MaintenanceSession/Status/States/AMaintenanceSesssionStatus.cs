namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States {

    /// <summary>
    ///     Abstract class that represents a maintenance session state,  There will be one
    /// descendent for each posible state that could be reported when querying for the 
    /// maintenance session state.
    /// </summary>
    public abstract class AMaintenanceSesssionStatus {

        /// <summary>
        ///     Maintenance session 
        /// </summary>
        public abstract MaintenanceSessionState state { get; }

    }
}