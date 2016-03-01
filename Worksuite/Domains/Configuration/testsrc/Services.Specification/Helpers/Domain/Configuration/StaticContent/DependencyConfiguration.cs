using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Rebind< IQueryRepository<StaticContents>
                       , IEntityRepository<StaticContents>
                       , FakeStaticContentRepository>()
                .To<FakeStaticContentRepository>()
                .InScope(x => scope)
                ;    

             kernel
                .Rebind<IcheckUrlExist
                    , FakeUrlExistTest>()
                .To<FakeUrlExistTest>()
                .InScope(x => scope);
             }
           
        }

    }

