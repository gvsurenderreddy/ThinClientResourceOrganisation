using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Remove
{
    public class RemoveJobTitle
                    : RemoveReferenceData<JobTitle, RemoveJobTitleRequest, RemoveJobTitleResponse>,
                        IRemoveJobTitle
    {
        public RemoveJobTitle(IUnitOfWork the_unit_of_work,
                              IEntityRepository<JobTitle> the_title_repository
                             )
            : base(the_unit_of_work,
                   the_title_repository
                  ) { }
    }
}