using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove
{
    public class RemoveOperationsCalendarDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IRemoveOperationsCalendar >()
                .To< RemoveOperationsCalendar >()
                ;

            kernel
                .Bind< IGetRemoveOperationsCalendarRequest >()
                .To< GetRemoveOperationsCalendarRequest >()
                ;
        }
    }
}