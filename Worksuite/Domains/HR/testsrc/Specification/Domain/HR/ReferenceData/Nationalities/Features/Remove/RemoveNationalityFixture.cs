using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Remove
{
    public class RemoveNationalityFixture
                        : RemoveRefereceDataFixture< RemoveNationalityRequest, RemoveNationalityResponse, IRemoveNationality >
    {
        public RemoveNationalityFixture(    IRemoveNationality the_command,
                                            IRequestHelper< RemoveNationalityRequest > the_request_builder
                                       )
                        : base( the_command, the_request_builder ) {}
    }
}