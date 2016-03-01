using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.New
{
    public class NewLocationFixture
                        : NewReferenceDataFixture<Location,
                                                  CreateLocationRequest,
                                                  CreateLocationResponse,
                                                  ICreateLocation
                                                 >
    {
        public NewLocationFixture(ICreateLocation the_command,
                                  IRequestHelper<CreateLocationRequest> the_request_builder,
                                  IEntityRepository<Location> the_repository
                                 )
            : base(the_command,
                   the_request_builder,
                   the_repository
                  ) { }
    }
}