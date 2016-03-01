using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Addresses {

    public class DependencyConfiguration : ADependencyConfiguration {

        public override void configure ( IKernel kernel, Func<IContext, object> scope ) {
        

            kernel
                .Rebind< IRequestHelper<NewAddressRequest>
                       , NewAddressRequestHelper>()
                .To<NewAddressRequestHelper>()
                ;

        }

    }

}