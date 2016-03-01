using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< ICreateNationality >()
                .To< CreateNationality >()
                ;

            kernel
                .Bind< IGetCreateNationalityRequest >()
                .To< GetCreateNationalityRequest >()
                ;
        }
    }
}