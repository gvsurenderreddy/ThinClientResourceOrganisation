using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Remove {

    public class RemoveTitle 
                    : RemoveReferenceData<Title,RemoveTitleRequest,RemoveTitleResponse>
                    , IRemoveTitle {

        public RemoveTitle 
                     ( IUnitOfWork the_unit_of_work
                     , IEntityRepository<Title> the_title_repository ) 
              : base
                     ( the_unit_of_work
                     , the_title_repository ) {}
    }
}