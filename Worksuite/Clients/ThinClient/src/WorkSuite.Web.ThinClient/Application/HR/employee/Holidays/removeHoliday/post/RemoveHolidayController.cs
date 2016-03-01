using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.removeHoliday;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.removeHoliday.post
{
    public class RemoveHolidayController : Controller
    {
        public ActionResult SubmitRequest(RemoveHolidayRequest remove_holiday_request)
        {
            var remove_holiday_response = remove_holiday_request_handler.execute(remove_holiday_request);

            var field_validation_response = response_builder.build(remove_holiday_response);

            Response.StatusCode = field_validation_response.has_errors ? 400 : 200;

            return Json(field_validation_response, JsonRequestBehavior.AllowGet);

        }


        public RemoveHolidayController(IRemoveHolidayRequestHandler the_remove_holiday_request_handler
                                       , FieldSetValidationResponseBuilder<RemoveHolidayResponse> the_response_builder)
        {
            remove_holiday_request_handler = Guard.IsNotNull(the_remove_holiday_request_handler, "the_remove_holiday_request_handler");
            response_builder = Guard.IsNotNull(the_response_builder, "the_response_builder");
        }

        private readonly IRemoveHolidayRequestHandler remove_holiday_request_handler;
        private readonly FieldSetValidationResponseBuilder<RemoveHolidayResponse> response_builder;
    }
}