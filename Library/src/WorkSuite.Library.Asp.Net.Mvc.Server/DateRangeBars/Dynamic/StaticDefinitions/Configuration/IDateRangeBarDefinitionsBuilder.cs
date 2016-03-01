using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration
{
    public interface IDateRangeBarDefinitionsBuilder
    {
        void build(IDependencyResolver resolver);
    }
}