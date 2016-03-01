using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.JobTitles
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Rebind<IQueryRepository<JobTitle>,
                        IEntityRepository<JobTitle>,
                        FakeJobTitleRepository>()
                .To<FakeJobTitleRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<ReferenceDataBuilder<JobTitle>,
                        JobTitleBuilder>()
                .To<JobTitleBuilder>()
                ;

            kernel
                .Rebind<IRequestHelper<CreateJobTitleRequest>,
                        NewJobTitleRequestHelper>()
                .To<NewJobTitleRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<UpdateJobTitleRequest>,
                    UpdateJobTitleRequestHelper>()
                .To<UpdateJobTitleRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<RemoveJobTitleRequest>,
                    RemoveJobTitleRequestHelper>()
                .To<RemoveJobTitleRequestHelper>()
                ;
        }
    }
}