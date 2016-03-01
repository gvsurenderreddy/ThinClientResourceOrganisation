using System.Collections.Generic;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository
{
    public class TableFieldMetadataRepository<S> : ITableFieldMetadataRepository<S>
    {

        public TableFieldMetadata<S> metadata_for ( PropertyInfo property ) {

            if (repository.ContainsKey(property.Name))
            {
                return repository[property.Name];
            }

            // to do: hide field by default
            return new TableFieldMetadata<S>();
        }

        public void add_metadata(string property_name, TableFieldMetadata<S> metadata) {
            repository[property_name] = metadata;
        }

        public IEnumerable<TableFieldMetadata<S>> fields {
            get {
                return repository
                        .Values;
            }
        }

        private readonly Dictionary<string, TableFieldMetadata<S>> repository = new Dictionary<string, TableFieldMetadata<S>>();

    }
}