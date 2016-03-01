using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.post;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.addSickness.post
{
    public class Policy : FieldSetValidationResponsePolicyDefinitionBuilder<AddSicknessResponse>
    {
        public override void build_field_responses(FieldSetValidationResponseDefinitionBuilder<AddSicknessResponse> builder)
        {
            builder.for_service_status<AddSicknessRequestHandlerStatuses.InvalidSicknessDate>()
               .add_field_validation_status_message("sickness_date", content_repository.get_resource_value("new_sickness_request_post_resource_invalid_sickness_date"))
               .add_field_validation_status_message("sickness_date.day", content_repository.get_resource_value("new_sickness_request_post_resource_invalid_sickness_date"))
               .add_field_validation_status_message("sickness_date.month", content_repository.get_resource_value("new_sickness_request_post_resource_invalid_sickness_date"))
               .add_field_validation_status_message("sickness_date.year", content_repository.get_resource_value("new_sickness_request_post_resource_invalid_sickness_date"))
               ;
        }

        public override string success_message()
        {
            return content_repository.get_resource_value("new_sickness_request_post_resource_page_level_success_message");
        }

        public override string error_message()
        {
            return content_repository.get_resource_value("new_sickness_request_post_resource_page_level_error_message");
        }
    }
}