using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Publish;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Presentation.Publish.Get
{
    public class MetadataConfiguration : PageMetadataBuilder
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
                .add_entry(Home.Get.Resources.page_id,Home.Get.Resources.page_title)
                .add_entry(OperationalCalendars.View.Page.Resources.page_id,OperationalCalendars.View.Page.Resources.page_title)
                .add_entry(View.Page.Resources.page_id,View.Page.Resources.page_title
                );

        }

        protected override void build_worklow_metadata
                                 (global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder.IWorkflowMetadataBuilder builder)
        {
            builder.for_page(Resources.page_id)
                .for_editor<PublishShiftCalendarRequest>()
                .for_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Cancel>()
                .add_destination(View.Page.Resources.page_id, View.Page.Resources.page_title)
                .for_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.SubmitNew>()
                .add_destination(View.Page.Resources.page_id, View.Page.Resources.page_title);


        }
    }
}