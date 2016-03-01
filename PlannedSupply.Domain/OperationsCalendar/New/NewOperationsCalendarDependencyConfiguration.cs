using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.New
{
    public class NewOperationsCalendarDependencyConfiguration
                            : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IGetNewOperationsCalendarRequest >()
                .To< GetNewOperationsCalendarRequest >()
                ;

            kernel
                .Bind< INewOperationsCalendar >()
                .To< NewOperationsCalendar >()
                ;

            kernel
                .Bind< ICanAddNewOperationsCalendar >()
                .To< CanAddNewOperationsCalendar >()
                ;
        }
    }
}