using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.New;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeQualifications
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Rebind<    IRequestHelper< NewEmployeeQualificationRequest >,
                            NewEmployeeQualificationRequestHelper
                       >()
                .To< NewEmployeeQualificationRequestHelper >()
                ;
        }
    }
}