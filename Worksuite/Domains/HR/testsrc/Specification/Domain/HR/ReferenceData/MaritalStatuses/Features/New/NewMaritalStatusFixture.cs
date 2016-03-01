using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.New
{
    public class NewMaritalStatusFixture
                    : NewReferenceDataFixture<MaritalStatus, CreateMaritalStatusRequest, CreateMaritalStatusResponse, ICreateMaritalStatus>
    {
        public NewMaritalStatusFixture( ICreateMaritalStatus the_command,
                                IRequestHelper<CreateMaritalStatusRequest> the_request_builder,
                                IEntityRepository<MaritalStatus> the_repository
                              )
                              : base(   the_command,
                                        the_request_builder,
                                        the_repository
                                    )
        {
        }
    }
}
