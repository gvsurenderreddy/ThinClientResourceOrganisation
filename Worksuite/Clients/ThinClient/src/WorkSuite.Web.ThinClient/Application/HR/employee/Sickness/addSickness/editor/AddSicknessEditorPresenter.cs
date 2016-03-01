using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.get;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.addSickness.editor
{
    public class AddSicknessEditorPresenter : Presenter
    {
        public ActionResult Editor( EmployeeIdentity employee )
        {
            return this
                .set_request(employee)
                .execute_get_request()
                .build_view();
        }


        private AddSicknessEditorPresenter set_request(EmployeeIdentity employee)
        {
           get_request = new GetAddSicknessRequest {employee_id = employee.employee_id};

            return this;
        }

        private AddSicknessEditorPresenter execute_get_request()
        {
            Guard.IsNotNull(get_request, "get_request");

            add_sickness_request = get_sickness_handler.execute(get_request);

            return this;
        }

        private ActionResult build_view()
        {
            Guard.IsNotNull(add_sickness_request, "add_sickness_request");

            var view_model = editor_builder.build(add_sickness_request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }


        public AddSicknessEditorPresenter(IGetAddSicknessRequestHandler get_sickness_handler
            , EditorBuilder<AddSicknessRequest> editor_builder)
        {
            this.get_sickness_handler = Guard.IsNotNull(get_sickness_handler, "get_sickness_handler");
            this.editor_builder = Guard.IsNotNull(editor_builder, "editor_builder");
        }


        private GetAddSicknessRequest get_request;
        private ServiceStatusResponse<AddSicknessRequest> add_sickness_request;

        private readonly IGetAddSicknessRequestHandler get_sickness_handler;
        private readonly EditorBuilder<AddSicknessRequest> editor_builder;
    }

}