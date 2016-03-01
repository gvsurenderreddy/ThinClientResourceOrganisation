using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.ReorderEditor
{
    public class ReorderAddressEditorPresenter : Presenter
    {
        private readonly IGetReorderAddressRequest get_reorder_request;
        private readonly EditorBuilder<ReorderAddressDetails> editor_builder;


        public ActionResult Editor(ReorderAddressRequest for_address)
        {
            var update_request = get_reorder_request.execute(for_address);
            var view_model = editor_builder.build(update_request.result);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public ReorderAddressEditorPresenter(IGetReorderAddressRequest get_update_request_query
                                            , EditorBuilder<ReorderAddressDetails> the_editor_builder)
        {
            get_reorder_request = Guard.IsNotNull(get_update_request_query, "get_update_request_query");
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
        }
    }
}