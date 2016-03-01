using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Model;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration {

    public class PageConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IPageModelMetadataRepository
                     , PageModelMetadataRepository>()
                .To<PageModelMetadataRepository>()
                .InSingletonScope()
                ;

            kernel
                .Bind<IPageModelMetadataBuilderFactory>()
                .To<PageModelMetadataBuilderFactory>()
                ;

        }
    }
}