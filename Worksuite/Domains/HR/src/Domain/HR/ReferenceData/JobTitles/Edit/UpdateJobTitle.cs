using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit
{
    public class UpdateJobTitle
                    : UpdateReferenceData<JobTitle, UpdateJobTitleRequest, UpdateJobTitleResponse, JobTitleUpdatedEvent>,
                        IUpdateJobTitle
    {
        public UpdateJobTitle(IUnitOfWork the_unit_of_work,
                              IEntityRepository<JobTitle> the_repository,
                              IEventPublisher<JobTitleUpdatedEvent> the_event_publisher,
                              Validator the_validator
                             )
            : base(the_unit_of_work,
                   the_repository,
                   the_event_publisher,
                   the_validator
                   )
        {
        }
    }
}