using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.get;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.addHoliday.editor
{
    public class AddHolidayEditorPresenter : Presenter
    {
        public ActionResult Editor( EmployeeIdentity employee )
        {
            return this
                      .create_get_add_holiday_request( employee )
                      .execute_get_request( )
                      .build_view( )
                      ;
        }

        private AddHolidayEditorPresenter create_get_add_holiday_request( EmployeeIdentity employee )
        {
            get_request = new GetAddHolidayRequest { employee_id = employee.employee_id };

            return this;
        }

        private AddHolidayEditorPresenter execute_get_request( )
        {
            Guard.IsNotNull( get_request, "get_request" );

            get_add_holiday_response = get_holiday_handler.execute( get_request );

            return this;
        }

        private ActionResult build_view( )
        {
            Guard.IsNotNull( get_add_holiday_response, "get_add_holiday_response" );

            var view_model = editor_builder.build( get_add_holiday_response.result );

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }


        public AddHolidayEditorPresenter( IGetAddHolidayRequestHandler get_holiday_handler
                                        , EditorBuilder<AddHolidayRequest> editor_builder )
        {
            this.get_holiday_handler = Guard.IsNotNull( get_holiday_handler, "get_holiday_handler" );
            this.editor_builder = Guard.IsNotNull( editor_builder, "editor_builder" );
        }

        private GetAddHolidayRequest get_request;
        private GetAddHolidayResponse get_add_holiday_response;

        private readonly IGetAddHolidayRequestHandler get_holiday_handler;
        private readonly EditorBuilder<AddHolidayRequest> editor_builder;
    }
}