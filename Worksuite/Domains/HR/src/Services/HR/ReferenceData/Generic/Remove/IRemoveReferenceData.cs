using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove {

    /// <summary>
    ///     Base interface that the concrete Remove reference data commands
    /// inherit from.
    /// </summary>
    /// <typeparam name="Q">
    ///     Response type returned by the concrete implementation 
    /// of the remove command.  It must be inherited from 
    /// <see cref="IRemoveReferenceData'1{P,Q}"/>
    /// </typeparam>
    public interface IRemoveReferenceData<P,Q> 
                        : ICommand<P, Q> 
                where P : RemoveReferenceDataRequest
                where Q : RemoveReferenceDataResponse { }
}