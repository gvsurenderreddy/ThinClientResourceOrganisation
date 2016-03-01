namespace WorkSuite.Configuration.Service.Management.ServiceStatus.Queries {

    /// <summary>
    ///     Service status when there is an active maintenance session
    /// </summary>
    public class ServiceIsInMaintenanceMode
                    : ServiceStatusDetails {
        
        /// <inheritdoc/>
        public override ServiceStates state {
            get { return ServiceStates.maintenance_mode; }
        }
    }
}