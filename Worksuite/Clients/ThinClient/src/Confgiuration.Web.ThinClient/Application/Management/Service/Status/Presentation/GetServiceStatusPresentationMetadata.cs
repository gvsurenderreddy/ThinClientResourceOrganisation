using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.Status.Presentation {

    public class GetServiceStatusPresentationMetadata {

        public ServiceStatusPresentationMetadata execute () {
            var service_status = get_service_status.execute(  ).result;

            switch ( service_status.state ) {
                case ServiceState.online: return new OnlineServiceStatusPresentationMetadata();
                case ServiceState.maintenance_mode: return new MaintenanceModeServiceStatusPresentationMetadata();
            }
            return new UnknownServiceStatusPresentationMetadata();

        }

        public GetServiceStatusPresentationMetadata 
                    ( IGetServiceStatus get_service_status_query ) {
            
            get_service_status = Guard.IsNotNull( get_service_status_query, "get_service_status_query" );
        }

        private readonly IGetServiceStatus get_service_status;        
    }

}