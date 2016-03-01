using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation.Premises;

namespace WTS.WorkSuite.HR.HR.Employees.addEmployee.post
{
    public class AddEmployeeRequestValidator
    {
        public IEnumerable<IServiceStatus> execute(AddEmployeeRequest the_request)
        {
            return this
                .set_request(the_request)
                .validate_employee_reference()
                .validate_forename()
                .validate_surname()
                .get_validation_statuses();

        }

        private AddEmployeeRequestValidator set_request(AddEmployeeRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private AddEmployeeRequestValidator validate_employee_reference()
        {
            Guard.IsNotNull(request, "request");


            premise_validator
                .for_field(request.employee_reference)
                .verify<AddEmployeeServiceStatuses.EmployeeReferenceIsMandatory>(is_mandatory)
                .verify<AddEmployeeServiceStatuses.EmployeeReferenceExceedsMaxCharacters>(exceeds_max_characters)
                .premise_holds<AddEmployeeServiceStatuses.EmployeeReferenceIsNotUnique>(employee_reference_is_unique())
                ;

            return this;
        }

        private AddEmployeeRequestValidator validate_forename()
        {
            Guard.IsNotNull(request, "request");


            premise_validator
                .for_field(request.forename)
                .verify<AddEmployeeServiceStatuses.EmployeeForenameIsMandatory>(is_mandatory)
                .verify<AddEmployeeServiceStatuses.EmployeeForenameExceedsMaxCharacters>(exceeds_max_characters)
                .verify<AddEmployeeServiceStatuses.EmployeeForenameHasInvalidCharacters>(name_is_valid)
                ;

            return this;
        }

        private AddEmployeeRequestValidator validate_surname()
        {
            Guard.IsNotNull(request, "request");


            premise_validator
                .for_field(request.surname)
                .verify<AddEmployeeServiceStatuses.EmployeeSurnameIsMandatory>(is_mandatory)
                .verify<AddEmployeeServiceStatuses.EmployeeSurnameExceedsMaxCharacters>(exceeds_max_characters)
                .verify<AddEmployeeServiceStatuses.EmployeeSurnameHasInvalidCharacters>(name_is_valid)
                ;

            return this;
        }

        public IEnumerable<IServiceStatus> get_validation_statuses()
        {
            return premise_validator.get_statuses();
        }


        private bool employee_reference_is_unique()
        {
            return
                !employee_repository.Entities.Any(e => e.employeeReference.Equals(request.employee_reference.Trim(),
                                                                                    StringComparison.InvariantCultureIgnoreCase));
        }


        public AddEmployeeRequestValidator(IEntityRepository<Employee> employee_repository
                                        , PremiseValidator premise_validator
                                        , TextFieldIsMandatory is_mandatory
                                        , TextFieldIsWithinDefaultNumberOfCharacters exceeds_max_characters
                                        , PersonsNameIsValid name_is_valid)
        {
            this.employee_repository = Guard.IsNotNull(employee_repository, "employee_repository");
            this.premise_validator = Guard.IsNotNull(premise_validator, "premise_validator");
            this.is_mandatory = Guard.IsNotNull(is_mandatory, "is_mandatory");
            this.exceeds_max_characters = Guard.IsNotNull(exceeds_max_characters, "exceeds_max_characters");
            this.name_is_valid = Guard.IsNotNull(name_is_valid, "name_is_valid");
        }

        private readonly IEntityRepository<Employee> employee_repository;
        private readonly PremiseValidator premise_validator;
        private readonly TextFieldIsMandatory is_mandatory;
        private readonly TextFieldIsWithinDefaultNumberOfCharacters exceeds_max_characters;
        private readonly PersonsNameIsValid name_is_valid;

        private AddEmployeeRequest request;
    }
}
