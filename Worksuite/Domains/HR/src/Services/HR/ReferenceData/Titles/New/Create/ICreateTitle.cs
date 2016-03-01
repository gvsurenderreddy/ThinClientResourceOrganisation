using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.New {

    /// <summary>
    ///     Creates a new title from the supplied request and returns the identity 
    /// of the new title in the response object. If the request was not valid the errors
    /// are reported in the response object and a null identity is returned.
    /// </summary>
    public interface ICreateTitle 
                        : ICreateReferenceData<CreateTitleRequest, CreateTitleResponse> {}

}