using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.New {

    /// <summary>
    ///     Creates a create gender request and fills it out with 
    /// any default values. This returns our standard response object
    /// with the request being the response property of that object.
    /// 
    /// Default values:
    /// 
    ///     description defaults to not specified to force user entry.
    /// 
    ///     is hidden defaults to false.
    /// </summary>
    public interface IGetCreateGenderRequest
                        : IGetCreateReferenceDataRequest<CreateGenderRequest,GetCreateGenderRequestResponse> {}

}