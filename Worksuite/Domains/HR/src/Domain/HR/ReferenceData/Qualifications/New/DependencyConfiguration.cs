using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New
{
    public class DependencyConfiguration
                        :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind< ICreateQualification >()
                .To< CreateQualification >()
                ;

            kernel
                .Bind< IGetCreateQualificationRequest >()
                .To< GetCreateQualificationRequest >()
                ;
        }
    }
}