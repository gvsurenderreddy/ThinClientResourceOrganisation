using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.EndAll {

    /// <summary>
    ///     Implementation of <see cref="IGetEndAllMaintenanceSessionsRequest"/> that just
    /// returns a new instance of <see cref="EndAllMaintenanceSessionsRequest "/>
    /// </summary>
    public class GetEndAllMaintenanceSessionsRequest 
                    : IGetEndAllMaintenanceSessionsRequest {

        public EndAllMaintenanceSessionsRequest execute ( ) {
            
            return new EndAllMaintenanceSessionsRequest {
                has_been_confirmed = false, // although this assignment not need it is there is to explicitly show that this should be false rather than an oversight
            };
        }

    }

}