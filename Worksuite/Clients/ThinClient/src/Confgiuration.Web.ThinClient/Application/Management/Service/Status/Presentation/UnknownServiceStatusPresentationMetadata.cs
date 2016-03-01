namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.Status.Presentation {


    /// <summary>
    ///     Metadata returned if the query encounters an unknown state.  This
    /// should only happen when adding a new state in development so we want the service 
    /// to go bang rather be subtle and allow us to miss setting up the styling.
    /// </summary>
    public class UnknownServiceStatusPresentationMetadata
                    : ServiceStatusPresentationMetadata {

        public override string border_class {
            get { throw new System.NotImplementedException( ); }
        }

        public override string description {
            get { throw new System.NotImplementedException( ); }
        }

        public override string description_class {
            get { throw new System.NotImplementedException( ); }
        }

    }

}