using WTS.WorkSuite.Library.CodeStrutures.Creational;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.New {

    /// <summary>
    ///     Template interface for creating reference data entries 
    /// </summary>
    public interface IGetCreateReferenceDataRequest<R,Q> 
                        : IFactory<Q>
                where R : CreateReferenceDataRequest
                where Q : GetCreateReferenceDataRequestResponse<R> {}

}