using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create
{
    /// <summary>
    ///     Provide a service to create a new MaritalStatus reference data, if the request is valid.
    /// </summary>
    public interface ICreateMaritalStatus
                            :   ICreateReferenceData<CreateMaritalStatusRequest, CreateMaritalStatusResponse> {}
}
