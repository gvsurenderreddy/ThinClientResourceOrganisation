using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static
{
    public class EditorFieldMetadataRepository<S> : IEditorFieldMetadataRepository<S>
    {
        public EditorFieldMetadata<S> metadata_for(PropertyInfo property)
        {
            if (repository.ContainsKey(property.Name))
            {
                return repository[property.Name];
            }

            return new EditorFieldMetadata<S>
            {
                is_included = m => false,
                status = EditorFieldStatus.excluded,
                classes = new Collection<string>()
            };
        }

        public void add_metadata(string property_name, EditorFieldMetadata<S> metadata)
        {
            repository[property_name] = metadata;
        }

        private readonly Dictionary<string, EditorFieldMetadata<S>> repository = new Dictionary<string, EditorFieldMetadata<S>>();
    }
}