using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Allocation.OperationCalendars;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Allocation.Services.Helpers.Domain.OperationCalendars {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope  ) {

            kernel
                .Rebind< IEntityRepository<AllocatedOperationCalendar>
                       , FakeOperationCalendarRepository >()
                .To< FakeOperationCalendarRepository >()
                .InScope( scope )
                ;
        }
    }
}