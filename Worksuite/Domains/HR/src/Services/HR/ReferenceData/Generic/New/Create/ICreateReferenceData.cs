using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.New {

    /// <summary>
    ///     Base command definition for creating a new instance of 
    /// a concrete reference data type
    /// </summary>
    /// <typeparam name="P">
    ///     The concrete request type that is used to create a new instance
    /// from. This must be a <see cref="CreateReferenceDataRequest"/> type
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The concrete response type that is return with the result of 
    /// the create request.  This must be a <see cref="CreateReferenceDataResponse"/>
    /// </typeparam>
    public interface ICreateReferenceData<P,Q> 
                        : ICommand<P,Q> 
                where P : CreateReferenceDataRequest
                where Q : CreateReferenceDataResponse { }

}