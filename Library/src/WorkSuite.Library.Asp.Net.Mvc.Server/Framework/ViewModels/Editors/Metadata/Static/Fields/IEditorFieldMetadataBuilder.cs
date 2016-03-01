using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static
{
    public interface IEditorFieldMetadataBuilder<S>
    {
        IEditorFieldMetadataBuilder<S> id(string value);

        IEditorFieldMetadataBuilder<S> id(Func<S, string> generator);

        IEditorFieldMetadataBuilder<S> label(string value);

        IEditorFieldMetadataBuilder<S> is_required(bool value);

        IEditorFieldMetadataBuilder<S> is_hidden();

        IEditorFieldMetadataBuilder<S> is_readonly();

        IEditorFieldMetadataBuilder<S> is_lookup();

        IEditorFieldMetadataBuilder<S> is_composed();

        IEditorFieldMetadataBuilder<S> help(string value);

        IEditorFieldMetadataBuilder<S> is_included(Func<S, bool> value);

        IEditorFieldMetadataBuilder<S> add_class(string value);

        IEditorFieldMetadataBuilder<S> readonly_display_string(Func<S, string> value);

        IEditorFieldMetadataBuilder<S> colour_picker_palette(Func<S, IsAViewElement> value);
    }
}