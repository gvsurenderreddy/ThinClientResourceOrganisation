using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.New {

    /// <summary>
    ///     Response returned by the ICreateReferenceDataRequest.  
    /// </summary>
    /// <typeparam name="Q">
    ///     The type of the Create request, this is needed because 
    ///     everything from the service layer returns a response object so
    ///     this is telling us what the actual request is. 
    /// </typeparam>
    public abstract class GetCreateReferenceDataRequestResponse<Q>
                            : Response<Q> 
                    where Q : CreateReferenceDataRequest {}
}