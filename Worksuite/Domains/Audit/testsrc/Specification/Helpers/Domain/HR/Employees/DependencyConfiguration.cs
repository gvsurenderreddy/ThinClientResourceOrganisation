using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope  ) {

            kernel
                .Rebind< IEntityRepository<EmployeeAuditTrail>
                     , FakeEmployeeRepository >()
                .To< FakeEmployeeRepository >()
                .InScope( scope )
                ;
        }
    }
}