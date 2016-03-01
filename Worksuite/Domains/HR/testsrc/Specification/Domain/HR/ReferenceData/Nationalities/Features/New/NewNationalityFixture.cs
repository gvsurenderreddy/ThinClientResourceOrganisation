using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.New
{
    public class NewNationalityFixture
                        : NewReferenceDataFixture< Nationality, CreateNationalityRequest, CreateNationalityResponse, ICreateNationality >
    {
        public NewNationalityFixture(   ICreateNationality the_command,
                                        IRequestHelper<CreateNationalityRequest> the_request_builder,
                                        IEntityRepository<Nationality> the_repository
                                    )
                        : base( the_command,
                                the_request_builder,
                                the_repository
                              ) {}
    }
}
