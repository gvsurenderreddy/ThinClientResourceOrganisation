using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.New {

    /// <summary>
    ///     Creates a new CreateGenderRequest
    /// </summary>
    public class GetCreateGenderRequest 
                    : GetCreateReferenceDataRequest<CreateGenderRequest,GetCreateGenderRequestResponse>
                    , IGetCreateGenderRequest { }

}