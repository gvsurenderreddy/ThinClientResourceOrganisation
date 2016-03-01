using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.MonthInference;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.get;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.post;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure( IKernel kernel
                                      , Func<IContext, object> scope )
        {
            kernel
                .Bind<IMonthSanitisation>( )
                .To<MonthInferenceSanitisation>( )
                ;
            
            kernel
                .Bind<IGetAddHolidayRequestHandler>( )
                .To<GetAddHolidayRequestHandler>( )
                ;

            kernel
                .Bind<IAddHolidayRequestHandler>( )
                .To<AddHolidayRequestHandler>( )
                ;

        }
    }
}
