using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.Application
{
    public interface ITableMetadataConfiguration
    {
        void apply(IDependencyResolver resolver); 
    }
}