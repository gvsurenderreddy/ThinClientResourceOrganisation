namespace WTS.WorkSuite.Library.DomainTypes.ServiceStates {

    /// <summary>
    ///     Details of the service status 
    /// </summary>
    public abstract class AServiceState {

        /// <summary>
        ///     The state of the service that the descendent represents
        /// </summary>
        public abstract ServiceState state { get;  }
    }
}