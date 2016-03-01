using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content.JsonContent;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.Content
{
    public class ContentDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel.Bind<IContentFileLocation>()
                    .To<ThinclientJsonContentFileLocation>().InSingletonScope();

            kernel.Bind<IContentDataProvider>()
                    .To<ContentDataFromJsonFileProvider>().InSingletonScope();

            kernel.Bind<IContentRepository>()
                    .To<ContentRepository>().InSingletonScope();
        }
    }

}