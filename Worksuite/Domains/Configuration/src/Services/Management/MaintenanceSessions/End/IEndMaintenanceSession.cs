using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Management.MaintenanceSessions.End {

    /// <summary>
    ///     End the specified maintenance session
    /// </summary>
    public interface IEndMaintenanceSession
                        : IQuery<MaintenanceSessionIdentity, EndMaintenanceSessionResponse> { }

}