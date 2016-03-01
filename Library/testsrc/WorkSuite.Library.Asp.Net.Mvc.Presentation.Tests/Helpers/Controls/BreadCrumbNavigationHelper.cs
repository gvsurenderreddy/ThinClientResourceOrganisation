using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls
{

    public class BreadCrumbNavigationHelper
    {

        public static BreadCrumbNavigation create_bread_crumb_navigation()
        {

            var crumbs = new List<NavigationItem>()
            {
                new NavigationItem()
                {
                    Description = "Home",
                    Url = "Home Url"
                }, 
                new NavigationItem()
                {
                    Description = "View",
                    Url = "View Url"
                }
            };

            return new BreadCrumbNavigation()
            {
                items = crumbs
            };
        }
    }
}