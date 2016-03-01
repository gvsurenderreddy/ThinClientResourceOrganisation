using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration
{
    public interface IDateRangePaletteDefinitionsBuilder
    {
        void build(IDependencyResolver resolver);
    }
}