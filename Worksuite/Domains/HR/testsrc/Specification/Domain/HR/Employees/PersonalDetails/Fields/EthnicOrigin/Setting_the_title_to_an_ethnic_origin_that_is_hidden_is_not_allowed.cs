using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.EthnicOrigin
{
    public class Setting_the_title_to_an_ethnic_origin_that_is_hidden_is_not_allowed
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
                var ethnic_origin_helper = DependencyResolver.resolve<EthnicOriginHelper>();
                var ethnic_origin = ethnic_origin_helper.add().is_hidden(true).entity;

                fixture.request.ethnic_origin_id = ethnic_origin.id;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeTrue();
            }
        }

        [TestClass]
        public class verify_employees_with_ethnic_origins_that_are_hidden_can_be_updates
                                : HRActArrangeAssertResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest,
                                                                                UpdateEmployeePersonalDetailsResponse,
                                                                                UpdateEmployeePersonalDetailsFixture
                                                                                >
        {
            protected override void arrange()
            {
                var ethnic_origins = DependencyResolver.resolve<FakeEthnicOriginRepository>();
                var ethnic_origin = ethnic_origins.Entities.Single(eo => eo.id == fixture.request.ethnic_origin_id);

                ethnic_origin.is_hidden = true;
            }

            protected override void assert()
            {
                fixture.response.has_errors.Should().BeFalse();
            }
        }
    }
}