using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand
{
    public class UpdateRequestHelper : IRequestHelper<UpdateEmployeePersonalDetailsRequest>
    {
        public UpdateEmployeePersonalDetailsRequest given_a_valid_request()
        {
            var title = title_helper.add().entity;
            var gender = gender_helper.add().entity;
            var maritalStatus = maritalStatus_helper.add().entity;
            var nationality = nationality_helper.add().entity;
            var ethnic_origin = ethnic_origin_helper.add().entity;

            var employee = new Employee
            {
                forename = "Fred",
                surname = "Smith",
                title = title,
                gender = gender,
                maritalStatus = maritalStatus,
                nationality = nationality,
                ethnicOrigin = ethnic_origin,
                othername = "other",
                dateofbirth = DateTime.Now.AddYears(-20),
                email = "a@me.c",
            };
            repository.add(employee);

            return new UpdateEmployeePersonalDetailsRequest
            {
                employee_id = employee.id,
                forename = employee.forename,
                surname = employee.surname,
                title_id = title.id,
                gender_id = gender.id,
                marital_status_id = maritalStatus.id,
                nationality_id = nationality.id,
                ethnic_origin_id = ethnic_origin.id,
                othername = employee.othername,
                date_of_birth = employee.dateofbirth.ToDateRequest(),
            };
        }

        public UpdateRequestHelper
            (FakeEmployeeRepository the_repository,
                TitleHelper the_title_helper,
                GenderHelper the_gender_helper,
                MaritalStatusHelper the_maritalStatus_helper,
                NationalityHelper the_nationality_helper,
                EthnicOriginHelper the_ethnic_origin_helper
            )
        {
            repository = Guard.IsNotNull(the_repository, "the_employee_repository");
            title_helper = Guard.IsNotNull(the_title_helper, "the_title_helper");
            gender_helper = Guard.IsNotNull(the_gender_helper, "the_gender_helper");
            maritalStatus_helper = Guard.IsNotNull(the_maritalStatus_helper, "the_maritalStatus_helper");
            nationality_helper = Guard.IsNotNull(the_nationality_helper, "the_nationality_helper");
            ethnic_origin_helper = Guard.IsNotNull(the_ethnic_origin_helper, "the_ethnic_origin_helper");
        }

        private readonly FakeEmployeeRepository repository;
        private readonly TitleHelper title_helper;
        private readonly GenderHelper gender_helper;
        private readonly MaritalStatusHelper maritalStatus_helper;
        private readonly NationalityHelper nationality_helper;
        private readonly EthnicOriginHelper ethnic_origin_helper;
    }
}