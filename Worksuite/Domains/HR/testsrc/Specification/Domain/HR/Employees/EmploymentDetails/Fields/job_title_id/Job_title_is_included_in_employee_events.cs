using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Fields.job_title_id
{
    public class Job_title_is_included_in_employee_events
    {
        [TestClass]
        public class employee_employment_details_updated_event
                        : HRResponseCommandSpecification<UpdateEmploymentDetailsRequest, UpdateEmploymentDetailsResponse, UpdateEmploymentDetailsFixture>
        {
            [TestMethod]
            public void Employee_job_title_id_is_included_in_the_employee_updated_event()
            {
                fixture.execute_command();

                fixture
                    .get_last_employee_employment_details_updated_event_for(fixture.entity)
                    .Match(

                        has_value:
                            update_event => update_event.job_title_id.Should().Be(fixture.entity.job_title.id),

                        nothing:
                            () => { Assert.Fail("event was not created"); }
                    );
            }

            [TestMethod]
            public void Employee_job_title_description_is_included_in_the_employee_updated_event()
            {
                fixture.execute_command();

                fixture
                    .get_last_employee_employment_details_updated_event_for(fixture.entity)
                    .Match(

                        has_value:
                            update_event => update_event.job_title_description.Should().Be(fixture.entity.job_title.description),

                        nothing:
                            () => { Assert.Fail("event was not created"); }
                    );
            }
        }
    }
}