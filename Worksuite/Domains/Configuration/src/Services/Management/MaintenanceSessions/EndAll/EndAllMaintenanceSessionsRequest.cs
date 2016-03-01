namespace WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll {

    /// <summary>
    ///     Request to ends all maintenance session.
    /// </summary>
    public class EndAllMaintenanceSessionsRequest {

        /// <summary>
        ///     Used to prove the the message has been confirmed, if it is not true
        /// end all will report an error
        /// </summary>
        public bool has_been_confirmed { get; set; }
    }
}