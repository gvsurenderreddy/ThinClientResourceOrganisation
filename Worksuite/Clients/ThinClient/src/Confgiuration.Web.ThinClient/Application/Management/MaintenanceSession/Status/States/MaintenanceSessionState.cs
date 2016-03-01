namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States
{

    /// <summary>
    ///     States that can be reported when querying whether a user is currently in a maintenance
    /// session or not.
    /// </summary>
    /// <remarks>
    ///     At the moment this is actuially the current session rather than current user because we 
    /// do not have the concept of a user so we report based on the current session rather than at 
    /// a specific user lever. 
    /// 
    /// e.g. 
    /// 
    /// If an admin starts a maintenance session on one machine then opens the application on another
    /// machine it will not report that user as being in maintenance session on the machine that
    /// the session was not start in.  This is not the desired behaviour but unitll we get the concept 
    /// of a user this is the best we have.
    /// </remarks>
    public enum MaintenanceSessionState
    {

        /// <summary>
        ///     reported when the current user has started but not yet ended a maintenance session
        /// in this session.
        /// </summary>
        active,

        /// <summary>
        ///     reported when the current user has not started a maintenance session
        /// in this session.
        /// </summary>
        not_active,
    }
}