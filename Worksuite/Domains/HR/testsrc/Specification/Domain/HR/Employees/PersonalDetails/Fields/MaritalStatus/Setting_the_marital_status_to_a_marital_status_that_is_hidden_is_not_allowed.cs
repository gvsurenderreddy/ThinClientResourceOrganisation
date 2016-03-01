using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.MaritalStatus
{
    public class Setting_the_marital_status_to_a_marital_status_that_is_hidden_is_not_allowed
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
                var marital_status_helper = DependencyResolver.resolve<MaritalStatusHelper>();
                var marital_status = marital_status_helper.add().is_hidden(true).entity;

                fixture.request.marital_status_id = marital_status.id;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeTrue();
            }
        }

        [TestClass]
        public class verify_employees_with_marital_statuses_that_are_hidden_can_be_updates
                        : HRActArrangeAssertResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest,
                                                                            UpdateEmployeePersonalDetailsResponse,
                                                                            UpdateEmployeePersonalDetailsFixture
                                                                        >
        {
            protected override void arrange()
            {
                var marital_statuses = DependencyResolver.resolve<FakeMaritalStatusRepository>();
                var marital_status = marital_statuses.Entities.Single(ms => ms.id == fixture.request.marital_status_id);

                marital_status.is_hidden = true;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeFalse();
            }
        }
    }
}