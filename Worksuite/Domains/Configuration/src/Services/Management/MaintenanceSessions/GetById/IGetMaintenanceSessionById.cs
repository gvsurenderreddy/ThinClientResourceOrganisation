using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Management.MaintenanceSessions.GetById {

    /// <summary>
    ///     Returns the details of a specific maintenance session.
    /// </summary>
    public interface IGetMaintenanceSessionById
                        : IQuery<MaintenanceSessionIdentity, GetMaintenanceSessionByIdResponse> {}
}