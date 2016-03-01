using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.post;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.addHoliday.post
{
    public class Policy : FieldSetValidationResponsePolicyDefinitionBuilder<AddHolidayResponse>
    {
        public override void build_field_responses( FieldSetValidationResponseDefinitionBuilder<AddHolidayResponse> builder )
        {
            builder.for_service_status<AddHolidayRequestHandlerStatuses.InvalidHolidayDate>()
                .add_field_validation_status_message("holiday_date", content_repository.get_resource_value("new_holiday_request_post_resource_invalid_holiday_date"))
                .add_field_validation_status_message("holiday_date.day", content_repository.get_resource_value("new_holiday_request_post_resource_invalid_holiday_date"))
                .add_field_validation_status_message("holiday_date.month", content_repository.get_resource_value("new_holiday_request_post_resource_invalid_holiday_date"))
                .add_field_validation_status_message("holiday_date.year", content_repository.get_resource_value("new_holiday_request_post_resource_invalid_holiday_date"))
                ;

        }

        public override string success_message()
        {
            return content_repository.get_resource_value("new_holiday_request_post_resource_page_level_success_message");
        }

        public override string error_message()
        {
            return content_repository.get_resource_value("new_holiday_request_post_resource_page_level_error_message");
        }
    }
}