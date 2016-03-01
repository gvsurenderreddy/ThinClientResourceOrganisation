using WTS.WorkSuite.Library.CodeStrutures.Creational;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit {

    public interface IGetUpdateReferenceDataRequest<R,Q>
                        : IFactory<ReferenceDataIdentity, Q>
                where R : UpdateReferenceDataRequest
                where Q : GetUpdateReferenceDataRequestResponse<R>  { }

}