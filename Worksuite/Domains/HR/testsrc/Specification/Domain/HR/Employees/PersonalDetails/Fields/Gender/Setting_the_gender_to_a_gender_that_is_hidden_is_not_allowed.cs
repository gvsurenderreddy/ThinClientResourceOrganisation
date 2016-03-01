using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Gender
{
    public class Setting_the_gender_to_a_gender_that_is_hidden_is_not_allowed
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
                var gender_helper = DependencyResolver.resolve<GenderHelper>();
                var gender = gender_helper.add().is_hidden(true).entity;

                fixture.request.gender_id = gender.id;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeTrue();
            }
        }

        [TestClass]
        public class verify_employees_with_genders_that_are_hidden_can_be_updates
                        : HRActArrangeAssertResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest,
                                                                            UpdateEmployeePersonalDetailsResponse,
                                                                            UpdateEmployeePersonalDetailsFixture
                                                                        >
        {
            protected override void arrange()
            {
                var genders = DependencyResolver.resolve<FakeGenderRepository>();
                var gender = genders.Entities.Single(g => g.id == fixture.request.gender_id);

                gender.is_hidden = true;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeFalse();
            }
        }
    }
}