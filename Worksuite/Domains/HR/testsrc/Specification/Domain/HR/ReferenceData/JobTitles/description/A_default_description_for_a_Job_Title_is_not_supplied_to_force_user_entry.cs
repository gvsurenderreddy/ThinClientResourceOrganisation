using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.description
{
    [TestClass]
    public class A_default_description_for_a_Job_Title_is_not_supplied_to_force_user_entry
                        : A_default_description_is_not_supplied_to_force_user_entry<CreateJobTitleRequest,
                                                                                    GetCreateJobTitleRequestResponse,
                                                                                    IGetCreateJobTitleRequest
                                                                                   > { }
}