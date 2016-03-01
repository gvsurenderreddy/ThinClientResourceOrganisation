using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Remove {

    public class RemoveTitleRequestHelper 
                    : RemoveReferenceDataRequestBuilder<Title,RemoveTitleRequest> {

        public RemoveTitleRequestHelper 
                        ( IEntityRepository<Title> the_repository ) 
                : base 
                        ( the_repository ) {}
    }
}