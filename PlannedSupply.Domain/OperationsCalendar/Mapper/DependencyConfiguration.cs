using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Mapper
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {

            kernel
                .Bind<IOperationalCalendarSummaryMapper>()
                .To<OperationalCalendarSummaryMapper>()
                ;
        }
    }
}