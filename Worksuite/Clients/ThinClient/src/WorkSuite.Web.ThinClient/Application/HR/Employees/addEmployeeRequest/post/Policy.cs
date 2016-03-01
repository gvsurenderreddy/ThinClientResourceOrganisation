using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addEmployeeRequest.post
{
    public class Policy : FieldSetValidationResponsePolicyDefinitionBuilder<AddEmployeeResponse>
    {
        public override void build_field_responses(FieldSetValidationResponseDefinitionBuilder<AddEmployeeResponse> builder)
        {
            //employee_reference
            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeReferenceIsMandatory>()
                .add_field_validation_status_message("employee_reference", content_repository.get_resource_value("add_employee_request_post_resource_employee_reference_is_mandatory"))
                ;

            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeReferenceExceedsMaxCharacters>()
                .add_field_validation_status_message("employee_reference", exceeds_max_characters_content())
                ;

            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeReferenceIsNotUnique>()
                .add_field_validation_status_message("employee_reference", content_repository.get_resource_value("add_employee_request_post_resource_employee_reference_is_not_unique"))
                ;

            //employee_forename
            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeForenameIsMandatory>()
                .add_field_validation_status_message("forename", content_repository.get_resource_value("add_employee_request_post_resource_employee_forename_is_mandatory"))
                ;

            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeForenameHasInvalidCharacters>()
                .add_field_validation_status_message("forename", persons_name_has_invalid_characters_content())
                ;

            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeForenameExceedsMaxCharacters>()
                .add_field_validation_status_message("forename", exceeds_max_characters_content())
                ;

            //employee_surname
            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeSurnameIsMandatory>()
                .add_field_validation_status_message("surname", content_repository.get_resource_value("add_employee_request_post_resource_employee_surname_is_mandatory"))
                ;

            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeSurnameHasInvalidCharacters>()
                .add_field_validation_status_message("surname", persons_name_has_invalid_characters_content())
                ;

            builder.for_service_status<AddEmployeeServiceStatuses.EmployeeSurnameExceedsMaxCharacters>()
                .add_field_validation_status_message("surname", exceeds_max_characters_content())
                ;
        }
        
        public override string success_message()
        {
            return content_repository.get_resource_value("add_employee_request_post_resource_success_message");
        }

        public override string error_message()
        {
            return content_repository.get_resource_value("add_employee_request_post_resource_error_message");
        }

        private string exceeds_max_characters_content()
        {
            return
                string.Format(
                    content_repository.get_resource_value(
                        "application_resource_text_field_exceeds_max_characters")
                    , ValidationConstraints.max_text_field_length);
        }

        private string persons_name_has_invalid_characters_content()
        {
            return content_repository.get_resource_value("application_resource_persons_name_has_invalid_characters");
        }

    }
}