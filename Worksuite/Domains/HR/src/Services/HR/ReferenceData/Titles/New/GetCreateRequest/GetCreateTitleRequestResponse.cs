using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.New {

    /// <summary>
    ///     Response object returned by the <see cref="IGetCreateTitleRequest"/>.  This is our
    /// standard response object with the CreateRequest as it's response property
    /// </summary>
    public class GetCreateTitleRequestResponse 
                    : GetCreateReferenceDataRequestResponse<CreateTitleRequest> {}
}