using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.is_hidden
{
    [TestClass]
    public class Is_Hidden_for_a_Title_defaults_to_false_for_a_job_title
                        : Is_Hidden_defaults_to_false<CreateJobTitleRequest,
                                                      GetCreateJobTitleRequestResponse,
                                                      IGetCreateJobTitleRequest
                                                     > { }
}