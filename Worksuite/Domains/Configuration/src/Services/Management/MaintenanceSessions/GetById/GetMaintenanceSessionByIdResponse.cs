using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Management.MaintenanceSessions.GetById {

    /// <summary>
    ///     Response returned by the <see cref="IGetMaintenanceSessionById"/> query
    /// </summary>
    public class GetMaintenanceSessionByIdResponse
                    : Response<MaintenanceSessionDetails> {}
}