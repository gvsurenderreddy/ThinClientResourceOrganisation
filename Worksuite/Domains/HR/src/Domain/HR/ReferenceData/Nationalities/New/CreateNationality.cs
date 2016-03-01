using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New
{
    public class CreateNationality
                    :   CreateReferenceData< Nationality, CreateNationalityRequest, CreateNationalityResponse >,
                        ICreateNationality
    {
        public CreateNationality(   IUnitOfWork the_unit_of_work,
                                    Validator the_validator,
                                    IEntityRepository< Nationality > the_repository
                                )
                    : base( the_unit_of_work,
                            the_validator,
                            the_repository
                          ) {}
    }
}
