using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSummary;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees {

    public class EmployeeDetailsDependencyConfiguration : ADependencyConfiguration {

        public override void configure ( IKernel kernel, Func<IContext, object> scope  ) {

            kernel
                .Bind<IGetAllEmployeeDetails>()
                .To<GetAllEmployeeDetails>()
                ;

            kernel
                .Bind<IEmployeeDetailsDetailsMapper>()
                .To<EmployeeDetailsMapper>()
                ;

            kernel
                .Bind<IGetEmployeeSummary>()
                .To<GetEmployeeSummary>()
                ;
        }
    }

}