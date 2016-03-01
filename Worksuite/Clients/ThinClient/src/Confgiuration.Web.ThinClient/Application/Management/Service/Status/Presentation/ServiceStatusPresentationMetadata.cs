namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.Status.Presentation {

    /// <summary>
    ///     Contains all the metadata needed in the gloabl layout
    /// for displaying the current status of the service
    /// </summary>
    public abstract class ServiceStatusPresentationMetadata {

        public abstract string border_class { get; }

        public abstract string description { get; }

        public abstract string description_class { get; }
    }

}