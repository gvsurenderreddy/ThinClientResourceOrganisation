
namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Model
{
    public interface IBreadCrumbNavigationBuilder
    {
        BreadCrumbNavigation get_navigation_path_for(string page_id); 
    }
}