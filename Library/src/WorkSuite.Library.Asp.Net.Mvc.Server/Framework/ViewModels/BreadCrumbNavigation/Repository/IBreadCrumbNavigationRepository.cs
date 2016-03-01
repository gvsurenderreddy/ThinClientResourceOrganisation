using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Repository
{
    public interface IBreadCrumbNavigationRepository
    {
        Dictionary<string, List<NavigationItemMetadata>> entries { get; }
    }
}
