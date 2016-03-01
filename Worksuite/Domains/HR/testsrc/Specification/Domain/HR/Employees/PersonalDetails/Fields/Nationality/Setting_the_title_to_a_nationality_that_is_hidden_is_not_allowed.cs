using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Nationality
{
    public class Setting_the_title_to_a_nationality_that_is_hidden_is_not_allowed
    {
        [TestClass]
        public class verify_set_to_hidden_causes_a_validation_errror
                        : HRActArrangeAssertResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest,
                                                                            UpdateEmployeePersonalDetailsResponse,
                                                                            UpdateEmployeePersonalDetailsFixture
                                                                        >
        {
            protected override void arrange()
            {
                var nationality_helper = DependencyResolver.resolve<NationalityHelper>();
                var nationality = nationality_helper.add().is_hidden(true).entity;

                fixture.request.nationality_id = nationality.id;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeTrue();
            }
        }

        [TestClass]
        public class verify_employees_with_nationalities_that_are_hidden_can_be_updates
                        : HRActArrangeAssertResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest,
                                                                            UpdateEmployeePersonalDetailsResponse,
                                                                            UpdateEmployeePersonalDetailsFixture
                                                                        >
        {
            protected override void arrange()
            {
                var nationalities = DependencyResolver.resolve<FakeTitleRepository>();
                var nationality = nationalities.Entities.Single(n => n.id == fixture.request.nationality_id);

                nationality.is_hidden = true;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeFalse();
            }
        }
    }
}