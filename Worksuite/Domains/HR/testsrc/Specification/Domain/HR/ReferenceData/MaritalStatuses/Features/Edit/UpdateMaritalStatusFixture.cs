using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit
{
    public class UpdateMaritalStatusFixture
                       : UpdateRefereceDataFixture< MaritalStatus, UpdateMaritalStatusRequest, UpdateMaritalStatusResponse, IUpdateMaritalStatus >
    {
        public UpdateMaritalStatusFixture(  IUpdateMaritalStatus theUpdateMaritalStatusCommand,
                                    IRequestHelper< UpdateMaritalStatusRequest > theUpdateMaritalStatusRequestBuilder,
                                    IEntityRepository< MaritalStatus > theMaritalStatusRepository
                                 )
                    :   base(   theUpdateMaritalStatusCommand,
                                theUpdateMaritalStatusRequestBuilder,
                                theMaritalStatusRepository
                            ) {}
    }
}
