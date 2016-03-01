using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.Service.Presentation.Helpers {

    public class FakeServiceLayerGetServiceStatus 
                    : IGetServiceStatus {

        public Configuration_ServiceStatusResponse execute ( ) {
            
            return new Configuration_ServiceStatusResponse {
                has_errors = false,
                messages = new ResponseMessage[]{},
                result = status,
            };
        }

        public AServiceState status { get; set; }

    }

}