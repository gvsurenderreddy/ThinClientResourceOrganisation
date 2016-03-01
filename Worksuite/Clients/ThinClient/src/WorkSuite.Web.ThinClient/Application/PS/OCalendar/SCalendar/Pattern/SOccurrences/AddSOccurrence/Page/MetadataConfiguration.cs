using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using Cancel = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Cancel;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.New.Presentation.Page
{
    public class MetadataConfiguration
                      : PageMetadataBuilder
    {
        protected override string page_id
        {
            get { return Resources.page_id; }
        }

        protected override void build_model_metadata
                                   (IPageModelMetadataBuilder model_metadata_builder)
        {
            model_metadata_builder
                .title(Resources.page_title)
                ;
        }

        protected override void build_bread_crumb_navigation_metadata
                                  (IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder)
        {
            bread_crumb_navigation_metadata_builder
                    .for_page(Resources.page_id)
                    .add_entry(Home.Get.Resources.page_id, Home.Get.Resources.page_title)
                    .add_entry(OperationalCalendars.View.Page.Resources.page_id, OperationalCalendars.View.Page.Resources.page_title)
                    .add_entry(View.Page.Resources.page_id, View.Page.Resources.page_title)
                    ;
        }

        protected override void build_worklow_metadata
                                 (global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder.IWorkflowMetadataBuilder builder)
        {
            builder.for_page(Resources.page_id)
                    .for_editor<NewShiftOccurrenceRequest>()
                        .for_action<SubmitNew>()
                               .add_post_existing_destination(Edit.Presentation.Page.Resources.page_id, Edit.Presentation.Page.Resources.page_title)
                               .add_destination(View.Page.Resources.page_id, PlaceholderMessages.placeholder_05_0017)
                        .for_action<Cancel>()
                                .add_destination(View.Page.Resources.page_id, View.Page.Resources.page_title);
        }
    }
}
