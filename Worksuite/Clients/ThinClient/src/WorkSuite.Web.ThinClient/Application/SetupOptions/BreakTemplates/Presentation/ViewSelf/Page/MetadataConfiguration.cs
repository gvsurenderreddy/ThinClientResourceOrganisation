using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.ViewSelf.Page
{
    public class MetadataConfiguration
                    : PageMetadataBuilder
    {
        protected override string page_id
        {
            get { return Resources.page_id; }
        }

        protected override void build_model_metadata(IPageModelMetadataBuilder model_metadata_builder)
        {
            model_metadata_builder
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
                .add_entry(ViewAll.Page.Resources.page_id,
                            ViewAll.Page.Resources.page_title
                          )
                ;
        }

        protected override void build_worklow_metadata(IWorkflowMetadataBuilder builder)
        {
            builder.for_page(Resources.page_id)
                        .for_editor<RemoveBreakTemplateRequest>()
                            .for_action<SubmitRemove>()
                                .error_destination(Resources.page_id, Resources.page_title);
        }
    }
}