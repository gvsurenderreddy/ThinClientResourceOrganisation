namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.Status.Presentation {

    public class OnlineServiceStatusPresentationMetadata 
                    : ServiceStatusPresentationMetadata {

        public override string border_class {
            get { return null; }
        }

        public override string description {
            get { return "Online"; }
        }

        public override string description_class {
            get { return "online"; }
        }

    }

}