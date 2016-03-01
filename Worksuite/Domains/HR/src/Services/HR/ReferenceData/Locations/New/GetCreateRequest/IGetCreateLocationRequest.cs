using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.GetCreateRequest
{
    /// <summary>
    ///     Creates a create location request and fills it out with
    /// any default values. This returns our standard response object
    /// with the request being the response property of that object.
    ///
    /// Default values:
    ///
    ///     description defaults to not specified to force user entry.
    ///
    ///     is hidden defaults to false.
    /// </summary>
    public interface IGetCreateLocationRequest
                        : IGetCreateReferenceDataRequest<CreateLocationRequest,
                                                         GetCreateLocationRequestResponse
                                                        > { }
}