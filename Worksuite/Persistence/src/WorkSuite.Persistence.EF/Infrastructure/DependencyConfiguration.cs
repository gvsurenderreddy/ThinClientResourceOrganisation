using System;
using System.Data.Entity;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.EntityFramework.Contexts.ConnectionStringProviders;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Persistence.EF;
using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.Library.Ninject.Configuration;
using ModelBuilder = WTS.WorkSuite.Persistence.EF.Domain.ModelBuilder;

namespace WTS.WorkSuite.Persistence.EF.Infrastructure {

    public class DependencyConfiguration : ADependencyConfiguration {

        public override void configure ( IKernel kernel, Func<IContext, object> scope ) {

            kernel
                .Bind( typeof( IEntityRepository<> ))
                .To( typeof(EntityRepository<> ))
                ;

            kernel
                .Bind( typeof( IQueryRepository<> ) )
                .To( typeof( QueryRepository<> ))
                ;

            kernel
                .Bind<IUnitOfWork>(  )
                .To<UnitOfWork >(  )
                ;

            kernel
                .Bind<DbContext>(  )
                .To<WorkSuiteContext>(  )
                .InScope( scope )
                ;


            kernel
                .Bind<IConnectionStringProvider>(  )
                .To<WorkSuiteConnectionStringProvider>()
                ;


            kernel
                .Bind<IModelConfiguration>()
                .To<ModelBuilder>()
                ;
        }

    }

}