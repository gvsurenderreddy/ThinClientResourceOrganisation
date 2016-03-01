namespace WorkSuite.Configuration.Service.Management.ServiceStatus.Queries {

    /// <summary>
    ///     Status when the service is online
    /// </summary>
    public class ServiceIsOnline
                    : ServiceStatusDetails {

        /// <inheritdoc/>
        public override ServiceStates state {
            get { return ServiceStates.online; }
        }
    }

}