using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Library.Ninject.Factory;
using WTS.WorkSuite.Library.CodeStrutures.Creational;

namespace WTS.WorkSuite.Services.Integration.ExternalServices
{

    /// <summary>
    ///     Dependency configuration for the worksuite external services.  External services
    /// will be anything like messaging services
    /// </summary>
    public class ExternalServicesBindings
                    : IDependencyConfiguration
    {

        public void configure
                        (IKernel kernel
                        , Func<IContext, object> scope)
        {

            apply_event_publisher_bindings_to_kernel(kernel);
        }


        private void apply_event_publisher_bindings_to_kernel
                        (IKernel kernel)
        {

            kernel
                .Bind(typeof(IEventPublisher<>))
                .To(typeof(PublishEventToSubscriberSynchronously<>))
                ;



            kernel.Bind(typeof(IFactory<>))
                    .To(typeof(NinjectDependencyFactory<>));

            kernel.Bind<IContext>()
                    .ToMethod(c => c.Request.ParentContext);

        }
    }
}