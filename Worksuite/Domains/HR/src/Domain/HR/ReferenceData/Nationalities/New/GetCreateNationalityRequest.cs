using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.GetCreateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New
{
    public class GetCreateNationalityRequest
                        :   GetCreateReferenceDataRequest< CreateNationalityRequest, GetCreateNationalityRequestResponse >,
                            IGetCreateNationalityRequest {}
}
