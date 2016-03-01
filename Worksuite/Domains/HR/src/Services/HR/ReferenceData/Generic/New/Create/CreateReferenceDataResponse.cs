using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.New {

    /// <summary>
    ///     Base response returned for a request to create a new instance of 
    /// a concrete reference data type.  It will contain the identity of the
    /// new reference data instance or the appropriate error messages.
    /// </summary>
    public abstract class CreateReferenceDataResponse
                            : Response<ReferenceDataIdentity> { }

}