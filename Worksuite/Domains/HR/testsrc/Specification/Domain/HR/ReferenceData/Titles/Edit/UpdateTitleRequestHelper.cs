using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Edit
{

    public class UpdateTitleRequestHelper 
                    : UpdateReferenceDataRequestBuilder<Title,UpdateTitleRequest> {

        public UpdateTitleRequestHelper 
                        ( IEntityRepository<Title> the_repository ) 
                : base 
                        ( the_repository ) {}
    }
}