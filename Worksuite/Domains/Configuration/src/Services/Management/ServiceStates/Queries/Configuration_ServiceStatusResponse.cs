using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;

namespace WorkSuite.Configuration.Service.Management.ServiceStates.Queries {

    /// <summary>
    ///     Response returned by the get service status query
    /// </summary>
    public class Configuration_ServiceStatusResponse
                    : Response<AServiceState> { }

}