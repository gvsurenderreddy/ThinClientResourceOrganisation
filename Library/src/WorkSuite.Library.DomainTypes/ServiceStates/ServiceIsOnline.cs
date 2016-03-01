namespace WTS.WorkSuite.Library.DomainTypes.ServiceStates {

    /// <summary>
    ///     Status when the service is online
    /// </summary>
    public class ServiceIsOnline
                    : AServiceState {

        /// <inheritdoc/>
        public override ServiceState state {
            get { return ServiceState.online; }
        }
    }

}