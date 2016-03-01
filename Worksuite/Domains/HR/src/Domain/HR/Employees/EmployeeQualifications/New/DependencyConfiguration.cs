using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IGetNewEmployeeQualificationRequest >()
                .To< GetNewEmployeeQualificationRequest >()
                ;

            kernel
                .Bind< INewEmployeeQualification >()
                .To< NewEmployeeQualification >()
                ;
        }
    }
}