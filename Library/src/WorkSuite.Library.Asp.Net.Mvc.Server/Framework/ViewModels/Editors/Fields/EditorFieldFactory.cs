using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.HiddenField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ImageField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ReadOnlyField;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields {

    public class EditorFieldFactory<S> : Factory<S, EditorFieldMetadata<S>>
    {

        public EditorFieldFactory 
                ( IEditorModelMetadataRepository<S> the_model_metadata_repository
                , IEditorFieldMetadataRepository<S> the_field_metadata_repository
                , ILookupFieldValuesRepository<S> the_lookup_values_repository ) 
          : base( the_model_metadata_repository, the_field_metadata_repository ) {

            lookup_values_repository = Guard.IsNotNull( the_lookup_values_repository, "the_lookup_values_repository" );
        }


        protected override IBuilder<S> builder_for ( PropertyInfo property  ) 
        {
            // Check any editor specific metadata first but if that does not
            // identify a field builder for the property let the parent factory
            // decided.
            
            var model_metadata = model_metadata_repository.metadata_for();
            var property_metadata = field_metadata_repository.metadata_for( property );

            // Hidden takes priority
            if (property_metadata.status == EditorFieldStatus.hidden) {
                return new AHiddenFieldBuilder<S>( model_metadata, property_metadata );
            }

            switch ( property_metadata.field_type ) {
                
                case FieldTypes.Lookup: return new ALookupFieldBuilder<S>(model_metadata, property_metadata, lookup_values_repository  );
                case FieldTypes.ReadOnly: return new AReadOnlyFieldBuilder<S>(model_metadata, property_metadata);
                case FieldTypes.image_id: return new AnImageFieldBuilder<S>(model_metadata, property_metadata);
            }

            return base.builder_for( property );
        }

        private ILookupFieldValuesRepository<S> lookup_values_repository;

    }
}