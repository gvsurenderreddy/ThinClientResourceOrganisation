namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static
{
    public interface IBreadCrumbNavigationMetadataBuilder
    {
        IBreadCrumbNavigationMetadataBuilder for_page(string page_id);

        IBreadCrumbNavigationMetadataBuilder add_entry(string page_id, string page_title);
    }
}