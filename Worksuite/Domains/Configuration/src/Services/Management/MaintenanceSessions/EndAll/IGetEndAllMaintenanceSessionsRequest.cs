using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll {

    /// <summary>
    ///     Creates an end all maintenance sessions request
    /// </summary>
    public interface IGetEndAllMaintenanceSessionsRequest 
                        : ICommand<EndAllMaintenanceSessionsRequest> { }

}