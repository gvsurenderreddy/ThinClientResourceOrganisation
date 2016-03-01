using System.Collections.Generic;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    public class ReportFieldMetadataRepository<S> : IReportFieldMetadataRepository<S> {

        public ReportFieldMetadata<S> metadata_for ( PropertyInfo property ) {
            
            if (repository.ContainsKey( property.Name )) {
                return repository[ property.Name ];
            }
            
            return new ReportFieldMetadata<S> {
                is_included = m => false,
                status = ReportFieldStatus.excluded,
            };
        }

        public void add_metadata ( string property_name, ReportFieldMetadata<S> metadata ) {
            repository[ property_name ] = metadata;
        }

        private readonly Dictionary<string,ReportFieldMetadata<S>> repository = new Dictionary<string, ReportFieldMetadata<S>>();
    }
}