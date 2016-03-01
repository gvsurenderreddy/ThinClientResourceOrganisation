using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Service.DocumentStore.Images.New;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.New
{
    public class NewImageDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IGetNewImageRequest>()
               .To<GetNewImageRequest>()
               ;

            kernel
                .Bind<INewImage>()
                .To<NewImage>()
                ;

            kernel
               .Bind<ICanAddNewImage>()
               .To<CanAddNewImage>()
               ;

            kernel
              .Bind<INewImageValidator>()
              .To<NewImageValidator>()
              ;
        }
    }
}
