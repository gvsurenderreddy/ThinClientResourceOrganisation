using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.updatePattern.get
{
    public class UpdatePatternPresenter
                        : Presenter
    {
        public ActionResult Editor(ShiftCalendarPatternIdentity the_shift_calendar_pattern_identity)
        {
            UpdateShiftCalendarPatternRequest request = _get_update_shift_calendar_pattern_request
                                                            .execute(the_shift_calendar_pattern_identity)
                                                            .result
                                                            ;

            var view_model = _update_shift_calendar_pattern_request_editor_builder
                                    .build(request)
                                    ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public UpdatePatternPresenter(IGetUpdateShiftCalendarPatternRequest the_get_update_shift_calendar_pattern_request,
                                                EditorBuilder<UpdateShiftCalendarPatternRequest> the_update_shift_calendar_pattern_request_editor_builder
                                            )
        {
            _get_update_shift_calendar_pattern_request = Guard.IsNotNull(the_get_update_shift_calendar_pattern_request,
                                                                        "the_get_update_shift_calendar_pattern_request"
                                                                        );

            _update_shift_calendar_pattern_request_editor_builder = Guard.IsNotNull(the_update_shift_calendar_pattern_request_editor_builder,
                                                                                    "the_update_shift_calendar_pattern_request_editor_builder"
                                                                                   );
        }

        private readonly IGetUpdateShiftCalendarPatternRequest _get_update_shift_calendar_pattern_request;

        private readonly EditorBuilder<UpdateShiftCalendarPatternRequest>
            _update_shift_calendar_pattern_request_editor_builder;
    }
}