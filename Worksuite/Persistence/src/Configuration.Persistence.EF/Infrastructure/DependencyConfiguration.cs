using System;
using System.Data.Entity;
using Configuration.Persistence.EF.Domain;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.EntityFramework.Contexts.ConnectionStringProviders;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Persistence.EF;
using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace Configuration.Persistence.EF.Infrastructure {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

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
                .To<ConfigurationContext>(  )
                .InScope( scope )
                ;

            kernel
                .Bind<IConnectionStringProvider>(  )
                .To<ConfigurationConnectionStringProvider>()
                ;

            kernel
                .Bind<IModelConfiguration>()
                .To<ModelBuilder>()
                ;
        }

    }

}