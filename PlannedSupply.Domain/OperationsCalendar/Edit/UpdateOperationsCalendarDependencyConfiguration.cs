using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit
{
    public class UpdateOperationsCalendarDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IGetUpdateOperationsCalendarRequest >()
                .To< GetUpdateOperationsCalendarRequest >()
                ;

            kernel
                .Bind< IUpdateOperationsCalendar >()
                .To< UpdateOperationsCalendar >()
                ;

            kernel
                .Bind< ICanUpdateOperationsCalendar >()
                .To< CanUpdateOperationsCalendar >()
                ;            
        }
    }
}