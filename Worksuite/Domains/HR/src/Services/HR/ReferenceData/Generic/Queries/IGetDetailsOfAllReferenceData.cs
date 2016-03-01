using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries {

    public interface IGetDetailsOfAllReferenceData<Q> 
                         : IQuery<Response<IEnumerable<Q>>> 
                where Q  : ReferenceDataDetails { }
}