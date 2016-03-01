using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Edit {

    public class UpdateTitleFixture 
                    : UpdateRefereceDataFixture<Title, UpdateTitleRequest,UpdateTitleResponse,IUpdateTitle> {

        public UpdateTitleFixture 
                       ( IUpdateTitle the_command
                       , IRequestHelper<UpdateTitleRequest> the_request_builder
                       , IEntityRepository<Title> the_repository ) 
                : base ( the_command
                       , the_request_builder
                       , the_repository ) {}

    }  
}