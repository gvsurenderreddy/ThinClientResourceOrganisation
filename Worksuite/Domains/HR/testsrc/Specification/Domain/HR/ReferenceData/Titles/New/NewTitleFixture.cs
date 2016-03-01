using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.New {

    public class NewTitleFixture 
                    : NewReferenceDataFixture<Title,CreateTitleRequest,CreateTitleResponse,ICreateTitle> {


        public NewTitleFixture 
                       ( ICreateTitle the_command
                       , IRequestHelper<CreateTitleRequest> the_request_builder
                       , IEntityRepository<Title> the_repository )
                : base ( the_command
                       , the_request_builder
                       , the_repository ) {}

    }
}