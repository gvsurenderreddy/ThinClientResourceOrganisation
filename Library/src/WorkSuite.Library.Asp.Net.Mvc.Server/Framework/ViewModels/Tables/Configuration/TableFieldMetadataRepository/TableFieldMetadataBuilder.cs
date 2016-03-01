using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository {

    public class TableFieldMetadataBuilder<S> : ITableFieldMetadataBuilder<S> {

        public TableFieldMetadataBuilder ( Action<TableFieldMetadata<S>> add_metadata ) {
            // assume that if we are setting metadata about a property we want it 
            // to be displayed in the table.
            metadata = new TableFieldMetadata<S> {
                is_included = true,
                id = m => string.Empty
            };

            add_metadata( metadata );
        }

        public ITableFieldMetadataBuilder<S> id(string value)
        {
            metadata.id =  m => value;

            return this;
        }

        public ITableFieldMetadataBuilder<S> id(Func<S, string> generator)
        {
            metadata.id = generator;

            return this;
        }

        public ITableFieldMetadataBuilder<S> lable ( string value ) {
            metadata.lable = value;

            return this;
        }

        public ITableFieldMetadataBuilder<S> is_required ( bool value ) {
            metadata.is_required = value;

            return this;
        }

        // metadata which is added to the repository
        private readonly TableFieldMetadata<S> metadata;

    }

}