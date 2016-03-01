using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications
{
    public class DependencyConfiguration
                        :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            // Fake Training repository
            kernel
                .Rebind<    IQueryRepository< Qualification >,
                            IEntityRepository< Qualification >,
                            FakeQualificationRepository >()
                .To< FakeQualificationRepository >()
                .InScope( x => scope )
                ;

            // Training builder
            kernel
                .Rebind<    ReferenceDataBuilder< Qualification >,
                            QualificationBuilder >()
                .To< QualificationBuilder >()
                ;

            kernel
                .Rebind<    IRequestHelper< CreateQualificationRequest >,
                            NewQualificationRequestHelper >()
                .To< NewQualificationRequestHelper >()
                ;

            kernel
                .Rebind<    IRequestHelper< UpdateQualificationRequest >,
                            UpdateQualificationRequestHelper >()
                .To< UpdateQualificationRequestHelper >()
                ;

            kernel
                .Rebind<    IRequestHelper< RemoveQualificationRequest >,
                            RemoveQualificationRequestHelper >()
                .To< RemoveQualificationRequestHelper >()
                ;
        }
    }
}