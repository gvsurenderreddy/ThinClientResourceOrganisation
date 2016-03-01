using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Locations
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Rebind<IQueryRepository<Location>,
                    IEntityRepository<Location>,
                    FakeLocationRepository>()
                .To<FakeLocationRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<ReferenceDataBuilder<Location>,
                    LocationBuilder>()
                .To<LocationBuilder>()
                ;

            kernel
                .Rebind<IRequestHelper<CreateLocationRequest>,
                    NewLocationRequestHelper>()
                .To<NewLocationRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<UpdateLocationRequest>,
                    UpdateLocationRequestHelper>()
                .To<UpdateLocationRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<RemoveLocationRequest>,
                    RemoveLocationRequestHelper>()
                .To<RemoveLocationRequestHelper>()
                ;
        }
    }
}