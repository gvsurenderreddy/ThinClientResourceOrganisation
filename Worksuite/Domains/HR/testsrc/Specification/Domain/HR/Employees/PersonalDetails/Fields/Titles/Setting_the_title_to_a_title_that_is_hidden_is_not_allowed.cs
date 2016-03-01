using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Titles {

    public class Setting_the_title_to_a_title_that_is_hidden_is_not_allowed {


        [TestClass]
        public class verify_set_to_hidden_causes_a_validation_errror
                        : HRActArrangeAssertResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture> {

            protected override void arrange () {
                var title_helper = DependencyResolver.resolve<TitleHelper>(  );
                var title = title_helper.add(  ).is_hidden( true ).entity;

                fixture.request.title_id = title.id;
            }

            protected override void assert () {
                
                fixture.response.has_errors.Should().BeTrue(  );

            }
        }

        [TestClass]
        public class verify_employees_with_titles_that_are_hidden_can_be_updates 
                        : HRActArrangeAssertResponseCommandSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture> {

            protected override void arrange () {
                var titles = DependencyResolver.resolve<FakeTitleRepository>(  );
                var title = titles.Entities.Single( t => t.id == fixture.request.title_id );
                
                title.is_hidden = true;                                              
            }

            protected override void assert () {
                
                fixture.response.has_errors.Should().BeFalse(  );
            }           
        }
    }

}