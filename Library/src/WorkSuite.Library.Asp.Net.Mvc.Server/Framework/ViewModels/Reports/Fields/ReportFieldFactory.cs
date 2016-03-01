using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.SimpleImageField;


namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields {

    public class ReportFieldFactory<S> : Factory<S,ReportFieldMetadata<S>> {

        public ReportFieldFactory 
                ( IReportModelMetadataRepository<S> the_model_metadata_repository
                , IReportFieldMetadataRepository<S> the_field_metadata_repository ) 
          : base( the_model_metadata_repository, the_field_metadata_repository ) {
        }

        protected override IBuilder<S> builder_for(PropertyInfo property)
        {

            var model_metadata = model_metadata_repository.metadata_for();
            var property_metadata = field_metadata_repository.metadata_for(property);

            switch (property_metadata.field_type)
            {
                case FieldTypes.SimpleImage: return new ASimpleImageFieldBuilder<S>(model_metadata, property_metadata);
            }

            return base.builder_for(property);
        }

    }
}