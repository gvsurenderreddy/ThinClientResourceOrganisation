using System;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static
{
    public class EditorFieldMetadataBuilder<S> : IEditorFieldMetadataBuilder<S>
    {
        public IEditorFieldMetadataBuilder<S> id(string value)
        {
            metadata.id = m => value;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> id(Func<S, string> generator)
        {
            metadata.id = generator;
            return this;
        }

        public IEditorFieldMetadataBuilder<S> label(string value)
        {
            metadata.lable = value;

            return this;
        }

        // to do: remove the parameter
        public IEditorFieldMetadataBuilder<S> is_required(bool value)
        {
            metadata.is_required = value;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> is_included(Func<S, bool> value)
        {
            metadata.is_included = value;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> add_class(string value)
        {
            metadata.classes.Add(value);

            return this;
        }

        public IEditorFieldMetadataBuilder<S> is_hidden()
        {
            metadata.status = EditorFieldStatus.hidden;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> is_lookup()
        {
            metadata.field_type = FieldTypes.Lookup;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> is_readonly()
        {
            metadata.field_type = FieldTypes.ReadOnly;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> readonly_display_string(Func<S, string> value)
        {
            metadata.field_type = FieldTypes.ReadOnly;

            metadata.readonly_display_string = value;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> colour_picker_palette(Func<S, IsAViewElement> value)
        {
            metadata.complementary_view_element = value;

            return this;
        }


        public IEditorFieldMetadataBuilder<S> is_composed()
        {
            metadata.field_type = FieldTypes.Composed;

            return this;
        }

        public IEditorFieldMetadataBuilder<S> help(string value)
        {
            metadata.help = value;

            return this;
        }

        public EditorFieldMetadataBuilder(Action<EditorFieldMetadata<S>> add_metadata)
        {
            metadata = new EditorFieldMetadata<S>
            {
                status = EditorFieldStatus.editable,
                is_included = m => true,
                id = m => string.Empty,
                classes = new Collection<string>()
            };

            add_metadata(metadata);
        }

        // metadata which is added to the repository
        private readonly EditorFieldMetadata<S> metadata;
    }
}