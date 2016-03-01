using WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.removeSickness.post
{
    public class Policy : FieldSetValidationResponsePolicyDefinitionBuilder<RemoveSicknessResponse>
    {
        public override void build_field_responses(FieldSetValidationResponseDefinitionBuilder<RemoveSicknessResponse> builder)
        {
           
        }

        public override string success_message()
        {
            return content_repository.get_resource_value("remove_sickness_request_post_resource_page_level_success_message");
        }

        //TO DO : we need to think about the error message in case delete fails.
        public override string error_message()
        {
            return "";
        }
    }
}