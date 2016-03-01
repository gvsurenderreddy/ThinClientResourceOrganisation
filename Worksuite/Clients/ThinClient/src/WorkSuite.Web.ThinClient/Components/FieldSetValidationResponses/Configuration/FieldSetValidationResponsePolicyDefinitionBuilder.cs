using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration
{
    [InheritedExport(typeof(IFieldSetValidationResponsePolicyDefinitionBuilder))]
    public abstract class FieldSetValidationResponsePolicyDefinitionBuilder<T>
                            : IFieldSetValidationResponsePolicyDefinitionBuilder
                    where T : ServiceStatusResponse
    {
        public void build(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            content_repository = resolver.GetService<IContentRepository>();

            var builder = resolver.GetService<FieldSetValidationResponseDefinitionBuilder<T>>();

            build_field_responses(builder);

            builder.add_page_level_success_message(success_message());

            builder.add_page_level_error_message(error_message());
        }

        public abstract void build_field_responses(FieldSetValidationResponseDefinitionBuilder<T> builder);

        public abstract string success_message();

        public abstract string error_message();

        /// <summary>
        /// provides an instance of the IContentRepository for derived instances to get content from a known key
        /// </summary>
        protected IContentRepository content_repository { get; private set; }
    }
}
