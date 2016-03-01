using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ReportBuilderFactory
{
    public class DependencyResolverReportBuilderFactory : AReportBuilderFactory
    {
        public ReportBuilder<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<ReportBuilder<S>>();
           
        }
    }
}