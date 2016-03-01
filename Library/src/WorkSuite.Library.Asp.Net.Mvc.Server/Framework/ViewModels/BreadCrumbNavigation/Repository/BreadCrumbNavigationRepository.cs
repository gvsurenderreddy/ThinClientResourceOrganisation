using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Repository
{
    public class BreadCrumbNavigationRepository : IBreadCrumbNavigationRepository
    {
        private readonly Dictionary<string, List<NavigationItemMetadata>> repository = new Dictionary<string, List<NavigationItemMetadata>>();

        public Dictionary<string, List<NavigationItemMetadata>> entries
        {
            get { return repository; }
        }
    }

}
