using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.HR.HR.Employees.addEmployee;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addNewEmployee.page
{
    public class AddNewEmployeePageDefinition : PageMetadataBuilder
    {
        protected override string page_id
        {
            get { return Resources.page_id; }
        }

        protected override void build_model_metadata(IPageModelMetadataBuilder builder)
        {
            builder
                .title(content_repository.get_resource_value("add_new_employee_page_resource_title"));
        }

        protected override void build_bread_crumb_navigation_metadata(IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder)
        {
            bread_crumb_navigation_metadata_builder
                .for_page(Resources.page_id)
                .add_entry(Home.Get.Resources.page_id,
                            Home.Get.Resources.page_title
                          );
        }

        protected override void build_worklow_metadata(IWorkflowMetadataBuilder builder)
        {
            builder.for_page(Resources.page_id)
                    .for_editor<AddEmployeeRequest>()
                        .for_action<SubmitNew>()
                               .add_destination(Home.Get.Resources.page_id, Home.Get.Resources.page_title)
                               .add_destination(Resources.page_id, content_repository.get_resource_value("add_new_employee_page_resource_save_and_add_another_employee"))
                               .add_post_existing_destination(employee.details.Get.Resources.page_id, content_repository.get_resource_value("add_new_employee_page_resource_save_and_edit_an_employee"))
                        .for_action<Cancel>()
                                .add_destination(Home.Get.Resources.page_id, Home.Get.Resources.page_title);
        }
    }
}