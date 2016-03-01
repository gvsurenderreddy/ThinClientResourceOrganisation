using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit
{
    public class DependencyConfiguration
                        :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IUpdateMaritalStatus >()
                .To< UpdateMaritalStatus >()
                ;

            kernel
                .Bind< IGetUpdateMaritalStatusRequest >()
                .To< GetUpdateMaritalStatusRequest >()
                ;
        }
    }
}
