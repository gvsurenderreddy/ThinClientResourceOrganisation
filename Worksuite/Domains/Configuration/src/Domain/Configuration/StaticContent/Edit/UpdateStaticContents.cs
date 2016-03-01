using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Domain.Configuration.StaticContent.Edit
{
    public class UpdateStaticContents :IUpdateStaticContents
 
    {
        public UpdateStaticContentResponse execute(UpdateStaticContentRequest the_request)
        {
            return this 
                .set_request( the_request )
                .sanatise_request()
                .validate()
                .add()
                .commit()
                .build_response();
        }

        private UpdateStaticContents set_request
                                 (UpdateStaticContentRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private UpdateStaticContents sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request = new UpdateStaticContentRequest
            {
                location_url = request.location_url.normalise_for_persistence()
            };
            return this;
        }

        private UpdateStaticContents validate()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            var url_test_response = _testUrlExist.verify(request.location_url);
            var url_field=validator.field("location_url");
            url_field.is_madatory(request.location_url, ErrorMessages.error_00_0034)
                .premise_holds(
                    validator.errors.Any() || url_test_response.status != UrlExistenceTestResponse.FailedToEstablishUrl,
                    ErrorMessages.error_00_0038);

            response_builder.add_errors(validator.errors);

            if (response_builder.has_errors)
            {
                response_builder.add_error(ErrorMessages.error_03_0013);
            }
            return this;
        }
        private UpdateStaticContents add()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(repository, "repository");
            repository.add(new StaticContents
            {
                location_url = request.location_url
            });
            return this;
        }

        private UpdateStaticContents commit()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(repository, "repository");
           
                Unit_Of_Work.Commit();
                response_builder.add_message(ErrorMessages.error_04_0016);
            
            
            return this;
        }

        private UpdateStaticContentResponse build_response()
        {
            return response_builder.build();
        }

        public UpdateStaticContents
                            (IEntityRepository<StaticContents> _repository
                             ,IUnitOfWork _unit_Of_Work 
                             ,Validator _validator
                             ,IcheckUrlExist theUrlExistTest)
        {
            repository = Guard.IsNotNull(_repository, "_repository");
            Unit_Of_Work = Guard.IsNotNull(_unit_Of_Work, "_unit_of_Work");
            validator = Guard.IsNotNull(_validator, "validator");
            _testUrlExist = Guard.IsNotNull(theUrlExistTest, "theUrlExistTest");
        }

        private readonly IEntityRepository<StaticContents> repository;
        private readonly IUnitOfWork Unit_Of_Work;
        private readonly Validator validator;
        private readonly ResponseBuilder<UpdateStaticContentResponse> response_builder=new ResponseBuilder<UpdateStaticContentResponse>();
        private UpdateStaticContentRequest request;
        private readonly IcheckUrlExist _testUrlExist;
    }

}