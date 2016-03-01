using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New
{
    /// <summary>
    ///     Creates a new qualification entry, if the request is valid.
    /// </summary>
    public class CreateQualification
                            :   CreateReferenceData< Qualification, CreateQualificationRequest, CreateQualificationResponse >,
                                ICreateQualification
    {
        public CreateQualification(  IUnitOfWork the_unit_of_work, 
                                    Validator the_validator,
                                    IEntityRepository<Qualification> the_repository
                                  )
                            :  base(   the_unit_of_work,
                                        the_validator,
                                        the_repository
                                    ) {}
    }
}