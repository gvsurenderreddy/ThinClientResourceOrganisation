namespace WorkSuite.Configuration.Service.Management.ServiceStatus.Queries {

    /// <summary>
    ///     States that the system can be in
    /// </summary>
    public enum ServiceStates {

        /// <summary>
        ///     The service is online and processing requests
        /// </summary>
        online,

        /// <summary>
        ///     One or more maintenance sessions are in progress.  In this state
        /// the service will not process any requests.
        /// </summary>
        maintenance_mode,

    }
}