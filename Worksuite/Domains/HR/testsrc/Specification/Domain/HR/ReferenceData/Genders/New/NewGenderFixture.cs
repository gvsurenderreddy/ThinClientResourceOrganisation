using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.New {

    public class NewGenderFixture 
                    : NewReferenceDataFixture<Gender,CreateGenderRequest,CreateGenderResponse,ICreateGender> {


        public NewGenderFixture 
                       ( ICreateGender the_command
                       , IRequestHelper<CreateGenderRequest> the_request_builder
                       , IEntityRepository<Gender> the_repository ) 
                : base ( the_command
                       , the_request_builder
                       , the_repository ) {}

    }
}