using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IUpdateNationality >()
                .To< UpdateNationality >()
                ;

            kernel
                .Bind< IGetUpdateNationalityRequest >()
                .To< GetUpdateNationalityRequest >()
                ;
        }
    }
}