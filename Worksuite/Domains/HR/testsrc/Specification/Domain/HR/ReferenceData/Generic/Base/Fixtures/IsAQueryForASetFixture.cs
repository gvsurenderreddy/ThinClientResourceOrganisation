using System.Collections.Generic;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures {

    public interface IsAQueryForASetFixture<E,Eb,R>
                where E  : ReferenceDataModel, new() 
                where Eb : ReferenceDataBuilder<E> 
                where R  : ReferenceDataDetails {

        Eb add ();

        void execute_query ();

        Response<IEnumerable<R>> response { get; }

    }
}