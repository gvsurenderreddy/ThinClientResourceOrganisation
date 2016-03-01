using WTS.WorkSuite.SupplyShortage.Employee.Holiday.removeHoliday;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.removeHoliday.post
{
    public class Policy : FieldSetValidationResponsePolicyDefinitionBuilder<RemoveHolidayResponse>
    {
        public override void build_field_responses(FieldSetValidationResponseDefinitionBuilder<RemoveHolidayResponse> builder)
        {
            
        }

        public override string success_message()
        {
            return content_repository.get_resource_value("remove_holiday_request_post_resource_page_level_success_message");
        }

        public override string error_message()
        {
            return "";
        }
    }
}