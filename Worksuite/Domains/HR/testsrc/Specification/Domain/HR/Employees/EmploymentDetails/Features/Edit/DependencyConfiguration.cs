using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmploymentDetails.Features.Edit
{
    public class DependencyConfiguration
                        : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func< IContext, object > scope ) {

            kernel
                .Rebind<    IRequestHelper< UpdateEmploymentDetailsRequest >,
                            UpdateEmploymentDetailsRequestHelper
                        >()
                .To< UpdateEmploymentDetailsRequestHelper >()
                ;

        }
    }
}