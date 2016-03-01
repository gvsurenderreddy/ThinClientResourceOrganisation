using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Service.DocumentStore.Images.Remove;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.Remove
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<IRemoveImage>().To<RemoveImage>();


            kernel.Bind<ICanRemoveImage>().To<CanRemoveImage>();
        }
    }
}
