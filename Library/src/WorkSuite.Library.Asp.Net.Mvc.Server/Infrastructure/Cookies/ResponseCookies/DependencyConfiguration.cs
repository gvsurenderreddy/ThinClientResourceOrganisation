using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.ResponseCookies {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {
            kernel
                .Bind<IResponseCookies>( )
                .To<HttpResponseCookies>()
                ;
        }
    }

}