using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.New {

    /// <summary>
    ///     Creates a new CreateTitleRequest
    /// </summary>
    public class GetCreateTitleRequest 
                    : GetCreateReferenceDataRequest<CreateTitleRequest,GetCreateTitleRequestResponse>
                    , IGetCreateTitleRequest { }

}