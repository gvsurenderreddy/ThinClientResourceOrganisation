using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Titles {

    [TestClass]
    public class A_title_can_be_edited_via_the_employees_personal_details
                    : FieldIsUpdatedSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture, Employee> {

        protected override void set_expected_value 
                                    ( UpdateEmployeePersonalDetailsRequest request ) {

            title = title_helper.add( ).entity;
            request.title_id = title.id;
        }

        protected override bool validate 
                                    ( UpdateEmployeePersonalDetailsRequest request
                                    , Employee entity ) {

            return entity.title != null && entity.title.id == title.id;
        }

        protected override void test_setup ( ) {

            base.test_setup( );
            title_helper = DependencyResolver.resolve<TitleHelper>( );
        }

        private Title title;
        private TitleHelper title_helper;
    }
}