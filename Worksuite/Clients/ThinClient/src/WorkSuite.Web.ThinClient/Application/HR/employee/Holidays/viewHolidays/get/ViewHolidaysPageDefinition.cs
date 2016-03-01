﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Holidays.viewHolidays.get
{
    public class ViewHolidaysPageDefinition : PageMetadataBuilder
    {
        protected override string page_id {
            get { return Resources.page_id; }
        }

        protected override void build_model_metadata( IPageModelMetadataBuilder builder )
        {
            builder
                .title(content_repository.get_resource_value("view_holidays_get_title"))
                ;
        }

        protected override void build_bread_crumb_navigation_metadata
                         ( IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder )
        {
            bread_crumb_navigation_metadata_builder
                .for_page(Resources.page_id)
                .add_entry(Home.Get.Resources.page_id,
                            Home.Get.Resources.page_title
                          )
                .add_entry(Employees.viewEmployees.get.Resources.page_id,
                            Employees.viewEmployees.get.Resources.page_title
                          )
                .add_entry(details.Get.Resources.page_id,
                            details.Get.Resources.page_title
                          )
                ;
        }

    }
}