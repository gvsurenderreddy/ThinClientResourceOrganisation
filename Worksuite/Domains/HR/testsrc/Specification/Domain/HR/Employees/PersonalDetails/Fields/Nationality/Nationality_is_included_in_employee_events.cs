﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Nationality
{
    public class Nationality_is_included_in_employee_events
    {
        [TestClass]
        public class Employee_personal_details_update_event
                                : HRResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest,
                                                                UpdateEmployeePersonalDetailsResponse,
                                                                UpdateEmployeePersonalDetailsFixture
                                                                >
        {
            [TestMethod]
            public void nationality_id_is_included_in_the_employee_personal_details_updated_event()
            {
                fixture.execute_command();

                fixture
                    .get_last_personal_details_updated_event_for(fixture.entity)
                    .Match(
                        has_value:
                            updated_event => updated_event.nationality_id.Should().Be(fixture.entity.nationality.id),

                        nothing:
                            () => { Assert.Fail(); }
                    );
            }

            [TestMethod]
            public void nationality_description_is_included_in_the_employee_personal_details_updated_event()
            {
                fixture.execute_command();

                fixture
                    .get_last_personal_details_updated_event_for(fixture.entity)
                    .Match(
                        has_value:
                            updated_event => updated_event.nationality_description.Should().Be(fixture.entity.nationality.description),

                        nothing:
                            () => { Assert.Fail(); }
                    );
            }
        }
    }
}