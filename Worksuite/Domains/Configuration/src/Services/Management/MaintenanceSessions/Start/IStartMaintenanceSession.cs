using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Management.MaintenanceSessions.Start {

    /// <summary>
    ///     Starts a new maintenance session, this has the effect of putting 
    /// the system into maintenance mode if it is not already.
    /// </summary>
    public interface IStartMaintenanceSession
                        : IResponseCommand<StartMaintenanceSessionResponse> {}

}