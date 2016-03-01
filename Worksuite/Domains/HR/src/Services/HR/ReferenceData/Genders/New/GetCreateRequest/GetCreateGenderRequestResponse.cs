using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.New {

    /// <summary>
    ///     Response object returned by the <see cref="IGetCreateGenderRequest"/>.  This is our
    /// standard response object with the CreateRequest as it's response property
    /// </summary>
    public class GetCreateGenderRequestResponse 
                    : GetCreateReferenceDataRequestResponse<CreateGenderRequest> {}
}