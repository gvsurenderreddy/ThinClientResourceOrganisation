using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries
{
    public class DependencyConfiguration
                        :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IGetDetailsOfAllQualifications >()
                .To< GetDetailsOfAllQualifications >()
                ;

            kernel
                .Bind< IGetDetailsOfASpecificQualification >()
                .To< GetDetailsOfASpecificQualification >()
                ;

            kernel
                .Bind< IGetDetailsOfQualificationsEligibleForEmployee >()
                .To< GetDetailsOfQualificationsEligibleForEmployee >()
                ;
        }
    }
}