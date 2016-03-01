namespace WorkSuite.Configuration.Service.Management.ServiceStatus.Queries {

    /// <summary>
    ///     Details of the service status 
    /// </summary>
    public abstract class ServiceStatusDetails {

        /// <summary>
        ///     The state of the service that the descendent represents
        /// </summary>
        public abstract ServiceStates state { get;  }
    }
}