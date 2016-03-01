using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Model
{
    public class BreadCrumbNavigation : IsAViewElement
    {
        public List<NavigationItem> items { get; set; }
    }
}
