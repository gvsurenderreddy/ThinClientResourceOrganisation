using System.Collections.Generic;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder
{
    public abstract class Builder<S, R, Q> : IBuilder<S>
                                                where R : Field<Q>, new()
    {
        public virtual Field build(S source, PropertyInfo property)
        {
            var result = create_instance(property);

            initialise_instance(result, property, source);

            return result;
        }

        protected Builder
            (FieldMetadata<S> the_field_metadata
            , IModelMetadata<S> the_model_metadata)
        {
            Guard.IsNotNull(the_field_metadata, "the_field_metadata");
            Guard.IsNotNull(the_model_metadata, "the_model_metadata");

            field_metadata = the_field_metadata;
            model_metadata = the_model_metadata;
        }

        protected virtual R create_instance(PropertyInfo property)
        {
            return new R();
        }

        protected virtual void initialise_instance
            (R instance
            , PropertyInfo property
            , S source)
        {
            Guard.IsNotNull(instance, "instance");
            Guard.IsNotNull(property, "property");
            Guard.IsNotNull(source, "source");

            instance.id = property_identity(source, property);
            instance.title = property_lable(property);
            instance.value = property_value(source, property);
            instance.is_required = property_is_required(property);
            instance.property_name = property.Name;
            instance.help = field_metadata.help ?? string.Empty;
            instance.icon = property_icon(source, property);
            instance.readonly_display_value = property_readonly_display_value(source, property);
            instance.is_rich_text = property_is_rich_text(property);
            instance.classes = property_classes(property);
            instance.complementary_view_element = property_view_element(source);
        }

        protected virtual string property_identity(S source, PropertyInfo property)
        {
            // If the same report is used multiple times in a view then we need
            // to make sure that the identity of each field is unique across all
            // instances.  We do this by adding a model specific extension to
            // each field id if one have been supplied.

            if (model_metadata.field_id_extension != null)
            {
                return field_metadata.id + model_metadata.field_id_extension(source);
            }
            return field_metadata.id(source);
        }

        protected virtual string property_lable(PropertyInfo property)
        {
            return field_metadata.lable;
        }

        protected virtual string property_icon(S source, PropertyInfo property)
        {
            if (field_metadata.icon != null)
            {
                return field_metadata.icon(source);
            }
            return string.Empty;
        }

        protected virtual string property_readonly_display_value(S source, PropertyInfo property)
        {
            if (field_metadata.readonly_display_string != null)
            {
                return field_metadata.readonly_display_string(source);
            }
            return string.Empty;
        }

        protected virtual IsAViewElement property_view_element(S source)
        {
            if (field_metadata.complementary_view_element != null)
            {
                return field_metadata.complementary_view_element(source);
            }
            return null;
        }

        protected virtual bool property_is_required(PropertyInfo property)
        {
            return field_metadata.is_required;
        }

        protected virtual ICollection<string> property_classes(PropertyInfo property)
        {
            return field_metadata.classes;
        }

        protected virtual bool property_is_rich_text(PropertyInfo property)
        {
            return field_metadata.is_rich_text;
        }

        protected abstract Q property_value(S source, PropertyInfo property);

        protected readonly FieldMetadata<S> field_metadata;
        protected readonly IModelMetadata<S> model_metadata;
    }
}