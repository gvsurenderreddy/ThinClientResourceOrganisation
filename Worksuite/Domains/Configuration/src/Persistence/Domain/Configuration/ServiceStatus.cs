namespace WorkSuite.Configuration.Persistence.Domain.Configuration {

    /// <summary>
    ///     service status record, a new one should be created every time the service's
    /// status is changed.
    /// </summary>
    public class ServiceStatus {
        
        /// <summary>
        ///     unique identity
        /// </summary>
        public int id
                    { get; set; }

        /// <summary>
        ///     identifies if this was to turn the service on or offline.
        /// </summary>
        public bool is_online 
                        { get; set; }
    }
}