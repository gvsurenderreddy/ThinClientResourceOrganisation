using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Routing;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Repository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Model
{
    public class BreadCrumbNavigationBuilder : IBreadCrumbNavigationBuilder
    {
        public BreadCrumbNavigationBuilder(INamedRouteUrlBuilder the_route_builder
                                            , IBreadCrumbNavigationRepository the_repository)
        {
            route_builder = Guard.IsNotNull(the_route_builder, "the_route_builder");
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        public BreadCrumbNavigation get_navigation_path_for(string page_id)
        {
            var route_params = get_route_data();
            List<NavigationItem> crumbs;

            if (repository.entries.Any(i => i.Key == page_id))
            {
                crumbs = transform(repository.entries[page_id], route_params);
            }
            else
            {
                crumbs = Enumerable.Empty<NavigationItem>().ToList();
            }


            return new BreadCrumbNavigation()
            {
                items = crumbs
            };
        }

        private readonly INamedRouteUrlBuilder route_builder;

        private readonly IBreadCrumbNavigationRepository repository;


        private List<NavigationItem> transform(IEnumerable<NavigationItemMetadata> items, RouteValueDictionary route_params)
        {

            return items.Select(i => new NavigationItem()
            {
                Description = i.page_title,
                Url = route_builder.build(new NamedRouteUrlDictionaryBuildDefinition()
                      {
                          route_name = i.page_id,
                          route_parameters_factory = () => route_params
                      })
            }).ToList();
        }


        // creates a url helper
        private RouteValueDictionary get_route_data()
        {
            var httpContextBase = new HttpContextWrapper(HttpContext.Current);
            var route_data = RouteTable.Routes.GetRouteData(httpContextBase) ?? new RouteData();

            var query_strings = HttpContext.Current.Request.QueryString;

            return AggregateRouteValues(query_strings, route_data.Values);
        }

        private RouteValueDictionary AggregateRouteValues(NameValueCollection collection, RouteValueDictionary route_dictionary)
        {
            var output = new RouteValueDictionary();

            foreach (var key in route_dictionary.Keys)
            {
                output.Add(key, route_dictionary[key]);
            }

            foreach (var key in collection.AllKeys)
            {
                output.Add(key, collection[key]);
            }

            return output;
        }
    }
}