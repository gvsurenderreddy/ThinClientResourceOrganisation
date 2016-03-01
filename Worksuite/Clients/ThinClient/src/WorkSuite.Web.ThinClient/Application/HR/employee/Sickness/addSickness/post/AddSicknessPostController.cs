using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.post;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.addSickness.post
{
    public class AddSicknessPostController : Controller
    {
        public ActionResult SubmitRequest(AddSicknessRequest add_sickness_request)
        {
            var add_sickness_response = add_sickness_request_handler.execute(add_sickness_request);

            var field_validation_response = response_builder.build(add_sickness_response);

            Response.StatusCode = field_validation_response.has_errors ? 400 : 200;

            return Json(field_validation_response, JsonRequestBehavior.AllowGet);
        }

        public AddSicknessPostController(IAddSicknessRequestHandler the_add_sickness_request_handler
                                       , FieldSetValidationResponseBuilder<AddSicknessResponse, SicknessIdentity> the_response_builder)
        {
            add_sickness_request_handler = Guard.IsNotNull(the_add_sickness_request_handler, "the_add_sickness_request_handler");
            response_builder = Guard.IsNotNull(the_response_builder, "the_response_builder");
        }

        private readonly IAddSicknessRequestHandler add_sickness_request_handler;
        private readonly FieldSetValidationResponseBuilder<AddSicknessResponse, SicknessIdentity> response_builder;
    }
}