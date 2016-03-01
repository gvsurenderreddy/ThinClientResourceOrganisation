using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Web.ThinClient.Components.FieldSetValidationResponses;

namespace WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.DependencyConfiguration
{
    public class FieldSetValidationResponseConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind(typeof(FieldSetValidationResponseDefinitionRepository<>))
                .To(typeof(FieldSetValidationResponseDefinitionRepository<>))
                .InSingletonScope()
                ;
        }
    }
}
