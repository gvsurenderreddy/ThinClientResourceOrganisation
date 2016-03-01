using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries {


    public interface IGetDetailsOfASpecificReferenceData<D> 
                       : IQuery<ReferenceDataIdentity, Response<D>> 
               where D : ReferenceDataDetails { }
}