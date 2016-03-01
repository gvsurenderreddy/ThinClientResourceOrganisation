namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.Status.Presentation {

    public class MaintenanceModeServiceStatusPresentationMetadata
                    : ServiceStatusPresentationMetadata {

        public override string border_class {
            get { return "maintenance"; }
        }

        public override string description {
            get { return "Maintenance mode"; }
        }

        public override string description_class {
            get { return "maintenance"; }
        }

    }

}