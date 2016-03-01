using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Repository;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static
{
    public class BreadCrumbNavigationMetadataBuilder : IBreadCrumbNavigationMetadataBuilder
    {
        private string key;

        public BreadCrumbNavigationMetadataBuilder(IBreadCrumbNavigationRepository the_repository)
        {
            repository = the_repository;
        }

        public IBreadCrumbNavigationMetadataBuilder for_page(string page_id)
        {
            key = page_id;

            if (!repository.entries.ContainsKey(key))
            {
                repository.entries.Add(key, new List<NavigationItemMetadata>());
            }

            return this;
        }

        public IBreadCrumbNavigationMetadataBuilder add_entry(string page_id, string page_title)
        {
            var item = new NavigationItemMetadata() { page_id = page_id, page_title = page_title };

            repository.entries[key].Add(item);

            return this;
        }


        private readonly IBreadCrumbNavigationRepository repository;
    }
}