using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ReportBuilderFactory
{
    public class DependencyResolverDetailsListBuilderFactory : ADetailsListBuilderFactory
    {
        public DetailsListBuilder<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<DetailsListBuilder<S>>();

        }
    }
}