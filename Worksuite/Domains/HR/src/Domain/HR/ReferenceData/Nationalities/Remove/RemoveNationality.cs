using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Remove
{
    public class RemoveNationality
                        :   RemoveReferenceData< Nationality, RemoveNationalityRequest, RemoveNationalityResponse >,
                            IRemoveNationality
    {
        public RemoveNationality(   IUnitOfWork the_unit_of_work,
                                    IEntityRepository< Nationality > the_title_repository
                                )
                        : base( the_unit_of_work, the_title_repository ) {}
    }
}