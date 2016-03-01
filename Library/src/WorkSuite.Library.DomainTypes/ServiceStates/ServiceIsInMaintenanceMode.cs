namespace WTS.WorkSuite.Library.DomainTypes.ServiceStates {

    /// <summary>
    ///     Service status when there is an active maintenance session
    /// </summary>
    public class ServiceIsInMaintenanceMode
                    : AServiceState {
        
        /// <inheritdoc/>
        public override ServiceState state {
            get { return ServiceState.maintenance_mode; }
        }
    }
}