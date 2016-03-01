using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.New
{
    public class NewQualificationFixture
                            :   NewReferenceDataFixture<  Qualification,
                                                            CreateQualificationRequest,
                                                            CreateQualificationResponse,
                                                            ICreateQualification
                                                       >
    {
        public NewQualificationFixture( ICreateQualification the_command,
                                        IRequestHelper< CreateQualificationRequest > the_request_builder,
                                        IEntityRepository< Qualification > the_repository
                                 )
                                 :  base(   the_command,
                                            the_request_builder,
                                            the_repository
                                        ) {}
    }
}