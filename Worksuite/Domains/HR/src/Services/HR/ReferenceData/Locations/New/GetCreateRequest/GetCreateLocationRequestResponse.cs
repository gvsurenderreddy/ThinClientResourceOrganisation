using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.GetCreateRequest
{
    /// <summary>
    ///     Response object returned by the <see cref="IGetCreateLocationRequest"/>.  This is our
    /// standard response object with the CreateRequest as it's response property
    /// </summary>
    public class GetCreateLocationRequestResponse
                    : GetCreateReferenceDataRequestResponse<CreateLocationRequest> { }
}