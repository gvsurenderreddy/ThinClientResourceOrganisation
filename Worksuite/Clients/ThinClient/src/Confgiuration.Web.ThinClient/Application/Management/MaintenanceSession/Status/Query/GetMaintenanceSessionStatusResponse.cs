using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query {

    /// <summary>
    ///     Response returned by the <see cref="GetMaintenanceSessionStatusResponse"/>
    /// </summary>
    public class GetMaintenanceSessionStatusResponse
                    : Response<AMaintenanceSesssionStatus> {}

}