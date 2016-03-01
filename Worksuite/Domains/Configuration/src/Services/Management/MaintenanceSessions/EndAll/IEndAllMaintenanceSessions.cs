using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll {

    /// <summary>
    ///     Ends all maintenance session.
    /// </summary>
    public interface IEndAllMaintenanceSessions
                        : ICommand<EndAllMaintenanceSessionsRequest,EndAllMaintenanceSessionsResponse> { }
}