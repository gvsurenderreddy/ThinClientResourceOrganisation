using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New {

    /// <summary>
    ///     Configures Ninject kernel with the NewAddress test dependencies
    /// </summary>
    public class DependencyConfiguration 
                    : ADependencyConfiguration {


        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Rebind< IRequestHelper<NewAddressRequest>
                       , NewAddressRequestHelper>()
                .To<NewAddressRequestHelper>()
                ;
        }

    }
}