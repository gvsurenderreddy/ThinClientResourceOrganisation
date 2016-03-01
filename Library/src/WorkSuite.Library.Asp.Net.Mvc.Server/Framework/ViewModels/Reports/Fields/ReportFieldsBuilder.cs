using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields.DisplayPolicy;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields {
    
    public class ReportFieldsBuilder<S> : FieldsBuilder<S,ReportFieldMetadata<S>> {
        public ReportFieldsBuilder
            (IShouldBeDisplayedOnReport<S> should_display_property_policy
             , ReportFieldFactory<S> the_field_factory
             , IReportFieldMetadataRepository<S> the_field_metadata_repository)
            : base(should_display_property_policy, the_field_factory)
        {

            field_metadata_repository = Guard.IsNotNull( the_field_metadata_repository, "the_field_metadata_repository");

        }

        protected override bool should_be_displayed ( PropertyInfo property_to_check, S source )
        {
            var field_metadata = field_metadata_repository.metadata_for(property_to_check);

            return base.should_be_displayed(property_to_check, source)
                && field_metadata.is_included( source );
        }

        private IReportFieldMetadataRepository<S> field_metadata_repository;
    }
}