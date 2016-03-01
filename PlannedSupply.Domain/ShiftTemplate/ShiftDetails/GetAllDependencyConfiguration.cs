using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails.GetAll;
using WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails.Mapper;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.GetAll;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails
{
    public class GetAllDependencyConfiguration 
                           : ADependencyConfiguration
    {
        public override void configure 
            ( IKernel kernel
              , Func<IContext
              , object> scope)
        {
            kernel.Bind<IGetAllShiftTemplates>()
                .To<GetAllShiftTemplateDetails>();

            kernel.Bind<IShiftTemplatesDetailsMapper>()
                .To<ShiftTemplatesDetailsMapper>();
        }
    }
}