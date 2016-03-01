using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Gender
{
    public class Gender_is_included_in_employee_events
    {
        [TestClass]
        public class Employee_personal_details_updated_event
                                : HRResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest,
                                                                UpdateEmployeePersonalDetailsResponse,
                                                                UpdateEmployeePersonalDetailsFixture
                                                                >
        {
            [TestMethod]
            public void Gender_id_is_included_in_the_employee_personal_details_updated_event()
            {
                fixture.execute_command();

                fixture
                    .get_last_personal_details_updated_event_for(fixture.entity)
                    .Match(
                        has_value:
                            updated_event => updated_event.gender_id.Should().Be(fixture.entity.gender.id),

                        nothing:
                            () => { Assert.Fail(); }
                    );
            }

            [TestMethod]
            public void Gender_description_is_included_in_the_employee_personal_details_updated_event()
            {
                fixture.execute_command();

                fixture
                    .get_last_personal_details_updated_event_for(fixture.entity)
                    .Match(
                        has_value:
                            updated_event => updated_event.gender_description.Should().Be(fixture.entity.gender.description),

                        nothing:
                            () => { Assert.Fail(); }
                    );
            }
        }
    }
}