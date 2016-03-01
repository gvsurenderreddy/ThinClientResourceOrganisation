using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.ById;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails
{
    public class EmploymentDetailsDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetEmploymentDetailsById>()
                .To<GetEmploymentDetailsById>()
                ;

            kernel
                .Bind<IGetUpdateEmploymentDetailsRequest>()
                .To<GetUpdateEmploymentDetailsRequest>()
                ;

            kernel
                .Bind<IUpdateEmploymentDetails>()
                .To<Edit.UpdateEmploymentDetails>()
                ;

            kernel
                .Bind<ICanUpdateEmploymentDetails>()
                .To<CanUpdateEmploymentDetails>()
                ;
        }
    }
}
