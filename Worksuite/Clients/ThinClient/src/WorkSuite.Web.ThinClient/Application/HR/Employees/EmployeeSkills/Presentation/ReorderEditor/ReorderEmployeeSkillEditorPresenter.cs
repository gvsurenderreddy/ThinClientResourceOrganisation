using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.ReorderEditor
{
    public class ReorderEmployeeSkillEditorPresenter
                            : Presenter
    {
        public ReorderEmployeeSkillEditorPresenter(  IGetReorderEmployeeSkillRequestDetails the_get_reorder_employee_skill_request,
                                                        EditorBuilder<ReorderEmployeeSkillDetails> the_reorder_employee_skill_editor_builder
                                                     )
        {
            _get_reorder_request = Guard.IsNotNull( the_get_reorder_employee_skill_request,
                "the_get_reorder_employee_skill_request" );
            _editor_builder = Guard.IsNotNull( the_reorder_employee_skill_editor_builder,
                "the_reorder_employee_skill_editor_builder" );
        }

        public ActionResult Editor( ReorderEmployeeSkillRequest the_reorder_employee_skill_request )
        {
            var update_employee_skill_request = _get_reorder_request.execute( the_reorder_employee_skill_request );
            var view_model = _editor_builder.build( update_employee_skill_request.result );

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        private readonly IGetReorderEmployeeSkillRequestDetails _get_reorder_request;
        private readonly EditorBuilder<ReorderEmployeeSkillDetails> _editor_builder;
    }
}