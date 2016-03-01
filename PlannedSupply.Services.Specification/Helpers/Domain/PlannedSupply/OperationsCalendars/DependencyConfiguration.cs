using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Rebind<IQueryRepository<WorkSuite.PlannedSupply.OperationsCalendars.OperationalCalendar>,
                                            IEntityRepository<WorkSuite.PlannedSupply.OperationsCalendars.OperationalCalendar>,
                                            FakeOperationsCalendarRepository
                                        >()
                .To<FakeOperationsCalendarRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<IRequestHelper<NewOperationsCalendarRequest>,
                                            NewOperationsCalendarRequestHelper
                                       >()
                .To<NewOperationsCalendarRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<UpdateOperationsCalendarRequest>,
                            UpdateOperationsCalendarRequestHelper
                       >()
                .To<UpdateOperationsCalendarRequestHelper>()
                ;
        }
    }
}