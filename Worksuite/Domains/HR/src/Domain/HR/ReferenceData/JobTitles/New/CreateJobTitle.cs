using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New
{
    /// <summary>
    ///     Creates a new job title entry if the request is valid.
    /// </summary>
    public class CreateJobTitle
                    : CreateReferenceData<JobTitle, CreateJobTitleRequest, CreateJobTitleResponse>,
                        ICreateJobTitle
    {
        public CreateJobTitle(IUnitOfWork the_unit_of_work,
                              Validator the_validator,
                              IEntityRepository<JobTitle> the_repository
                             )
            : base(the_unit_of_work,
                   the_validator,
                   the_repository
            ) { }
    }
}