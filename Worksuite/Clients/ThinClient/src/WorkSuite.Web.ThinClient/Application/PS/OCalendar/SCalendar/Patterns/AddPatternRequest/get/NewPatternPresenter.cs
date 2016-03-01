using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.GetCreateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.newPattern.get
{
    public class NewPatternPresenter
                        : Presenter
    {
        public ActionResult Editor(ShiftCalendarIdentity the_shift_calendar)
        {
            var new_shift_calendar_pattern_request = _get_new_shift_calendar_pattern_request
                                                            .execute(new ShiftCalendarPatternIdentity
                                                            {
                                                                shift_calendar_id = the_shift_calendar.shift_calendar_id,
                                                                operations_calendar_id = the_shift_calendar.operations_calendar_id
                                                            })
                                                            ;
            var view_model = _new_shift_calendar_pattern_request_editor_builder
                                    .build(new_shift_calendar_pattern_request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewPatternPresenter(IGetNewShiftCalendarPatternRequest the_get_create_shift_calendar_pattern_request,
                                    EditorBuilder<NewShiftCalendarPatternRequest> the_create_shift_calendar_pattern_request_editor_builder
                                  )
        {
            _get_new_shift_calendar_pattern_request = Guard.IsNotNull(the_get_create_shift_calendar_pattern_request,
                                                                        "the_get_create_shift_calendar_pattern_request"
                                                                        );
            _new_shift_calendar_pattern_request_editor_builder = Guard.IsNotNull(the_create_shift_calendar_pattern_request_editor_builder,
                                                                                    "the_create_shift_calendar_pattern_request_editor_builder"
                                                                                   );
        }

        private readonly IGetNewShiftCalendarPatternRequest _get_new_shift_calendar_pattern_request;
        private readonly EditorBuilder<NewShiftCalendarPatternRequest> _new_shift_calendar_pattern_request_editor_builder;
    }
}