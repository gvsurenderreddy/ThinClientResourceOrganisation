using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries
{
    /// <summary>
    ///     Get full details of all the ethnic origins in the system
    /// </summary>
    public interface IGetDetailsOfAllEthnicOrigins
                            : IGetDetailsOfAllReferenceData< EthnicOriginDetails > {}
}