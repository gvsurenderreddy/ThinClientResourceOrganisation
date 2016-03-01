using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.GetCreateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.New
{
    /// <summary>
    ///     Creates a new CreateLocationRequest
    /// </summary>
    public class GetCreateLocationRequest
                    : GetCreateReferenceDataRequest<CreateLocationRequest, GetCreateLocationRequestResponse>,
                        IGetCreateLocationRequest { }
}