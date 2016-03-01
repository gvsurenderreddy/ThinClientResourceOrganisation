using System.Web.Mvc;

namespace WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses.Configuration
{
    public interface IFieldSetValidationResponsePolicyDefinitionBuilder
    {
        void build(IDependencyResolver resolver);
    }
}
