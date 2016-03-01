using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.editor;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.get
{
    public class ConfirmAllocationPageDefinition : PageMetadataBuilder
    {
        protected override string page_id
        {
            get { return Resources.page_id; }
        }

        protected override void build_model_metadata(IPageModelMetadataBuilder model_metadata_builder)
        {
            model_metadata_builder
                .title(Resources.page_title);
        }

        protected override void build_bread_crumb_navigation_metadata(IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder)
        {
            bread_crumb_navigation_metadata_builder
                .for_page(Resources.page_id)
                    .add_entry(Home.Get.Resources.page_id
                               , Home.Get.Resources.page_title)
                    .add_entry(OperationalCalendars.View.Page.Resources.page_id
                               , OperationalCalendars.View.Page.Resources.page_title)
                    .add_entry(View.Page.Resources.page_id
                               , View.Page.Resources.page_title)
                    .add_entry(PlannedSupply.Presentation.ShiftCalendars.Presentation.Page.Resources.page_id,
                                PlannedSupply.Presentation.ShiftCalendars.Presentation.Page.Resources.page_title)
                    .add_entry(viewPatterns.get.Resources.page_id,
                                viewPatterns.get.Resources.page_title)
                    .add_entry(AllResources.get.Resources.page_id,
                                AllResources.get.Resources.page_title)
                                ;

        }


        protected override void build_worklow_metadata
                                (global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder.IWorkflowMetadataBuilder builder)
        {
            builder.for_page(Resources.page_id)
                 .for_editor<AllocationRequestDetails>()
                 .for_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Cancel>()
                                .add_destination(viewPatterns.get.Resources.page_id, viewPatterns.get.Resources.page_title)
                 .for_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.SubmitEdit>()
                                .add_destination(viewPatterns.get.Resources.page_id, viewPatterns.get.Resources.page_title);
        }
    }
}