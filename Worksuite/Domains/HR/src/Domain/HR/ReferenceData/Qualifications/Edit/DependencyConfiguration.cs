using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit
{
    public class DependencyConfiguration
                            :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IUpdateQualification >()
                .To< UpdateQualification >()
                ;

            kernel
                .Bind< IGetUpdateQualificationRequest >()
                .To< GetUpdateQualificationRequest >()
                ;
        }
    }
}