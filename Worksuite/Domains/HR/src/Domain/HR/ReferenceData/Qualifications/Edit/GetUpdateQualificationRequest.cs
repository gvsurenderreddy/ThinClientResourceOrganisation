using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.GetUpdateRequest;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit
{
    public class GetUpdateQualificationRequest
                            :   GetUpdateReferenceDataRequest< Qualification, UpdateQualificationRequest, GetUpdateQualificationRequestResponse >,
                                IGetUpdateQualificationRequest
    {
        public GetUpdateQualificationRequest( IEntityRepository< Qualification > the_repository )
                            :   base( the_repository ) {}
    }
}