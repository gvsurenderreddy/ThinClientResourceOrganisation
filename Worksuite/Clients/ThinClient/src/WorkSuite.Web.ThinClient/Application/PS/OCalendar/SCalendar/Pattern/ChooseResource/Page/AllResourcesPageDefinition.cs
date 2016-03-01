using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.AllResources.get
{
    public class AllResourcesPageDefinition : PageMetadataBuilder
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
                                ;

        }
    }
}