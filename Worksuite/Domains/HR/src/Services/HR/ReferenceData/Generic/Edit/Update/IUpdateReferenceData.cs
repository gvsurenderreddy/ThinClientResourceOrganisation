using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit.Update {

    public interface IUpdateReferenceData<P,Q> 
                        : ICommand<P,Q> 
                where P : UpdateReferenceDataRequest
                where Q : UpdateReferenceDataResponse { }
}