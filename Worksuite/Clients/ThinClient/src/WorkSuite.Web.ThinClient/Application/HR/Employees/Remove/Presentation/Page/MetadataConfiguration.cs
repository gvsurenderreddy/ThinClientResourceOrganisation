using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder;
using WTS.WorkSuite.HR.HR.Employees.Remove;
using Action = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Remove.Presentation.Page
{
    public class MetadataConfiguration
                    : PageMetadataBuilder
    {
        protected override string page_id
        {
            get { return Resources.page_id; }
        }

        protected override void build_model_metadata
                                    (IPageModelMetadataBuilder builder)
        {
            builder
                .title(Resources.page_title)
                ;
        }

        protected override void build_bread_crumb_navigation_metadata(IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder)
        {
            bread_crumb_navigation_metadata_builder
                .for_page(Resources.page_id)
                .add_entry(Home.Get.Resources.page_id,
                            Home.Get.Resources.page_title
                          )
                .add_entry(viewEmployees.get.Resources.page_id,
                            viewEmployees.get.Resources.page_title
                          )
                .add_entry(employee.details.Get.Resources.page_id,
                            employee.details.Get.Resources.page_title
                          )
                ;
        }

        protected override void build_worklow_metadata(IWorkflowMetadataBuilder builder)
        {

            builder.for_page(Resources.page_id)

                        .for_editor<RemoveEmployeeRequest>()
                            
                            .for_action<Action.Remove>()
                                .add_destination(viewEmployees.get.Resources.page_id, viewEmployees.get.Resources.page_title)
                                .add_destination(Home.Get.Resources.page_id, Home.Get.Resources.page_title)

                            .for_action<Action.Cancel>()
                                .add_destination(viewEmployees.get.Resources.page_id, viewEmployees.get.Resources.page_title)
                                .add_destination(Home.Get.Resources.page_id, Home.Get.Resources.page_title);
                    
                    
        }
    }
}