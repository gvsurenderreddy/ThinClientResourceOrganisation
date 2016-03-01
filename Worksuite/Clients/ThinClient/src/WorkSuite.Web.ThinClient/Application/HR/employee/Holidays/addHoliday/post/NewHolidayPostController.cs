using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.post;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.addHoliday.post
{
    public class NewHolidayPostController : Controller
    {
        public ActionResult SubmitRequest( AddHolidayRequest add_holiday_request )
        {
            var add_holiday_response = add_holiday_request_handler.execute(add_holiday_request);

            var field_validation_response = response_builder.build(add_holiday_response);

            Response.StatusCode = field_validation_response.has_errors ? 400 : 200;

            return Json(field_validation_response, JsonRequestBehavior.AllowGet);
        }

        public NewHolidayPostController( IAddHolidayRequestHandler add_holiday_request_handler
                                       , FieldSetValidationResponseBuilder<AddHolidayResponse, HolidayIdentity> response_builder )
        {
            this.add_holiday_request_handler = Guard.IsNotNull(add_holiday_request_handler, "add_holiday_request_handler");
            this.response_builder = Guard.IsNotNull(response_builder, "response_builder");
        }

        private readonly IAddHolidayRequestHandler add_holiday_request_handler;
        private readonly FieldSetValidationResponseBuilder<AddHolidayResponse, HolidayIdentity> response_builder;
    }
}