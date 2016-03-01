using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.UpdateCommand 
{

    public class UpdateRequestHelper : IRequestHelper<UpdateRequest>
    {

        private readonly FakeEmployeeRepository repository;
        private readonly TitleHelper title_helper;

        public UpdateRequestHelper
            (FakeEmployeeRepository the_repository
            , TitleHelper the_title_helper)
        {


            repository = Guard.IsNotNull(the_repository, "the_employee_repository");
            title_helper = Guard.IsNotNull(the_title_helper, "the_title_helper");
        }


        public UpdateRequest given_a_valid_request()
        {

            var title = title_helper.add().entity;

            var employee = new Employee
            {
                forename = "Fred",
                surname = "Smith",
                title = title,
                othername = "other",
                phone_number = "123",
                email = "a@b.c",
                mobile = "0778899",
                other = "other things ",
            };
            repository.add(employee);

            return new UpdateRequest
            {
                employee_id = employee.id,
                phone = employee.phone_number,
                email = employee.email,
                mobile = employee.mobile,
                other = employee.other,
            };
        }



    }

}