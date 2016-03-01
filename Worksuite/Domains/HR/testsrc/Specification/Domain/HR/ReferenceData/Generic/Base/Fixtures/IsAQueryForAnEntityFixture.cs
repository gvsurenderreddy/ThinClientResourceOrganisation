using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures {

    public interface IsAQueryForAnEntityFixture<E,Eb,R>
                where E  : ReferenceDataModel, new() 
                where Eb : ReferenceDataBuilder<E> 
                where R  : ReferenceDataDetails {

        
        Eb entity { get; }

        void execute_query ();

        Response<R> response { get; }

    }
}