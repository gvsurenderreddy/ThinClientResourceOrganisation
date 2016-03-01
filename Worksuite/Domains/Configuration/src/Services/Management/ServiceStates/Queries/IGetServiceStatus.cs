using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Management.ServiceStates.Queries {

    /// <summary>
    ///     returns the current status of the service 
    /// </summary>
    public interface IGetServiceStatus
                        : IQuery<Configuration_ServiceStatusResponse> { }

}