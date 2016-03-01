using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Queries.GetDetailsOfAllJobTitles
{
    [TestClass]
    public class Correctly_maps_description_for_a_job_title
                    : Correctly_maps_description<JobTitle,
                                                 JobTitleBuilder,
                                                 JobTitleDetails,
                                                 GetDetailsOfAllJobTitlesFixture
                                                > { }
}