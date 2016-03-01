using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit
{
    public class UpdateJobTitleFixture
                    : UpdateRefereceDataFixture<JobTitle,
                                                UpdateJobTitleRequest,
                                                UpdateJobTitleResponse,
                                                IUpdateJobTitle
                                               >
    {
        public UpdateJobTitleFixture(IUpdateJobTitle the_command,
                                     IRequestHelper<UpdateJobTitleRequest> the_request_builder,
                                     IEntityRepository<JobTitle> the_repository
                                    )
            : base(the_command,
                   the_request_builder,
                   the_repository
                   ) { }
    }
}