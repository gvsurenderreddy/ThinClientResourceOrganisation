using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields {
    
    public class EditorFieldsBuilder<S> : FieldsBuilder<S,EditorFieldMetadata<S>> {

        public EditorFieldsBuilder 
                   ( IShouldBeDisplayedOnEditor should_display_property_policy
                   , EditorFieldFactory<S> the_field_factory
            , IEditorFieldMetadataRepository<S> the_field_metadata_repository)
            : base(should_display_property_policy, the_field_factory)
        {

            field_metadata_repository = Guard.IsNotNull(the_field_metadata_repository, "the_field_metadata_repository");

        }


        protected override bool should_be_displayed(System.Reflection.PropertyInfo property_to_check, S source)
        {
            var field_metadata = field_metadata_repository.metadata_for(property_to_check);
            return base.should_be_displayed(property_to_check, source) && field_metadata.is_included(source);
        }

        private IEditorFieldMetadataRepository<S> field_metadata_repository;
    }
}