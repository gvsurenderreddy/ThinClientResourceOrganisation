using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Remove
{
    /// <summary>
    ///     Removes the ethnic origin specified in the supplied request.
    ///     It is not considered an error if the ethnic origin does not exist.
    /// </summary>
    public interface IRemoveEthnicOrigin
                            : IRemoveReferenceData< RemoveEthnicOriginRequest,
                                                    RemoveEthnicOriginResponse
                                                  > {}
}