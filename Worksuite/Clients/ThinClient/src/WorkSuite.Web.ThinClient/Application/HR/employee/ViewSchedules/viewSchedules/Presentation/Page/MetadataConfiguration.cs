using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.ViewSchedules.viewSchedules.Presentation.Page
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


        protected override void build_bread_crumb_navigation_metadata(
            IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder)
        {
            bread_crumb_navigation_metadata_builder
                .for_page(ViewSchedules.viewSchedules.Presentation.Page.Resources.page_id)
                .add_entry(Home.Get.Resources.page_id,
                            Home.Get.Resources.page_title
                          )
                .add_entry(Employees.viewEmployees.get.Resources.page_id,
                            Employees.viewEmployees.get.Resources.page_title
                          )
                .add_entry(employee.details.Get.Resources.page_id,
                            employee.details.Get.Resources.page_title
                          )
                ;
        }
    }
}