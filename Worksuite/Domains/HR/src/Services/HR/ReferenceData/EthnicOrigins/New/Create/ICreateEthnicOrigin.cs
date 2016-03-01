using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create
{
    /// <summary>
    ///     Provide a service to create an ethnic origin reference data, if the request is valid.
    /// </summary>
    public interface ICreateEthnicOrigin
                            : ICreateReferenceData< CreateEthnicOriginRequest, CreateEthnicOriginResponse > {}
}