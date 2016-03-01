using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.removeSickness.post
{
    public class RemoveSicknessController : Controller
    {
        public ActionResult SubmitRequest(RemoveSicknessRequest remove_sickness_request)
        {
            var remove_sickness_response = remove_sickness_request_handler.execute(remove_sickness_request);

            var field_validation_response = response_builder.build(remove_sickness_response);

            Response.StatusCode = field_validation_response.has_errors ? 400 : 200;

            return Json(field_validation_response, JsonRequestBehavior.AllowGet);

        }

        public RemoveSicknessController(IRemoveSicknessRequestHandler the_remove_sickness_request_handler
                                       , FieldSetValidationResponseBuilder<RemoveSicknessResponse> the_response_builder)
        {
            remove_sickness_request_handler = Guard.IsNotNull(the_remove_sickness_request_handler, "the_remove_sickness_request_handler");
            response_builder = Guard.IsNotNull(the_response_builder, "the_response_builder");
        }

        private readonly IRemoveSicknessRequestHandler remove_sickness_request_handler;
        private readonly FieldSetValidationResponseBuilder<RemoveSicknessResponse> response_builder;
    }
}