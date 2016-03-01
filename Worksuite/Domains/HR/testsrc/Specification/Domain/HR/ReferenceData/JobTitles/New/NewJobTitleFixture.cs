using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.New
{
    public class NewJobTitleFixture
                    : NewReferenceDataFixture<JobTitle, CreateJobTitleRequest, CreateJobTitleResponse, ICreateJobTitle>
    {
        public NewJobTitleFixture(ICreateJobTitle the_command,
                                  IRequestHelper<CreateJobTitleRequest> the_request_builder,
                                  IEntityRepository<JobTitle> the_repository
                                 )
            : base(the_command,
                   the_request_builder,
                   the_repository
                  ) { }
    }
}