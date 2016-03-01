using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.Application
{
    public abstract class TableMetadataConfiguration<S> : ITableMetadataConfiguration
    {
        public void apply(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            var model_metadata_builder = resolver.GetService<ITableModelMetadataBuilder<S>>();
            build_model_metadata(model_metadata_builder);

            var fields_metadata_builder = resolver.GetService<ITableFieldsMetadataBuilder<S>>();
            build_field_metadata(fields_metadata_builder);

          
        }
        protected abstract void build_model_metadata(ITableModelMetadataBuilder<S> model_metadata_builder);
        protected abstract void build_field_metadata(ITableFieldsMetadataBuilder<S> fields_metadata_builder);
       
    }
}