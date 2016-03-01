using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit {

    /// <summary>
    ///     Response object returned by the <see cref="IGetUpdateTitleRequest"/>.  This is our
    /// standard response object with the UpdateRequest as it's response property.
    /// </summary>
    public class GetUpdateTitleRequestResponse 
                    : GetUpdateReferenceDataRequestResponse<UpdateTitleRequest> {}                    

}