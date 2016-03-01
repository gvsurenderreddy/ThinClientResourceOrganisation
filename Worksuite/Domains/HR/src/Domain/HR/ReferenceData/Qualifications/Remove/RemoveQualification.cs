using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Remove
{
    public class RemoveQualification
                    : RemoveReferenceData< Qualification, RemoveQualificationRequest, RemoveQualificationResponse >,
                        IRemoveQualification
    {
        public RemoveQualification( IUnitOfWork theUnitOfWork,
                                    IEntityRepository< Qualification > theTrainingRepository
                                  )
                    :   base(   theUnitOfWork,
                                theTrainingRepository
                            ) {}
    }
}
