﻿using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IRemoveShiftOccurrence>()
                .To<RemoveShiftOccurrence>()
                ;

            kernel
                .Bind<IGetRemoveShiftOccurrenceRequest>()
                .To<GetRemoveShiftOccurrenceRequest>()
                ;
        }
    }
}