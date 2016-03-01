using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Domain.Configuration.Help.Edit
{
    public class UpdateHelp 
                 : IUpdateHelp
    {
        public UpdateHelpResponse execute(UpdateHelpRequest _request)
        {
            return this
                .set_request(_request)
                .sanatise_request()
                .validate()
                .add()
                .commite()
                .build_response();
        }

        private UpdateHelp set_request(UpdateHelpRequest _request)
        {
            request=Guard.IsNotNull(_request,"_request");
            return this;
        }

        private UpdateHelp sanatise_request()
        {
            if (response_Builder.has_errors) return this;
            Guard.IsNotNull(request, "request");
            request=new UpdateHelpRequest()
            {
                location_url = request.location_url.normalise_for_persistence()
            };
            return this;
        }

        private UpdateHelp validate()
        {
            if (response_Builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            var url_test_response = _testUrlExist.verify(request.location_url);
            var url_field = validator.field("location_url");
            url_field.is_madatory(request.location_url, ErrorMessages.error_00_0047)
                .premise_holds(validator.errors.Any() ||
                               url_test_response.status != UrlExistenceTestResponse.FailedToEstablishUrl,
                    ErrorMessages.error_00_0048);

            response_Builder.add_errors(validator.errors);

            if (response_Builder.has_errors)
            {
                response_Builder.add_error(ErrorMessages.error_03_0018);
            }
            return this;
        }

        private UpdateHelp add()
        {
            if (response_Builder.has_errors) return this;
            Guard.IsNotNull(repository, "repository");

            repository.add(new HelpUrls()
            {
                location_url = request.location_url
            });
            return this;
        }

        private UpdateHelp commite()
        {
            if (response_Builder.has_errors) return this;
            Guard.IsNotNull(repository, "repository");
           
            unit_of_work.Commit();
            response_Builder.add_message(ErrorMessages.error_04_0022);
            return this;
        }

        private UpdateHelpResponse build_response()
        {
            if (response_Builder.has_errors) return response_Builder.build();
            return response_Builder.build();
        }

        public UpdateHelp
                   (IEntityRepository<HelpUrls> _repository
                   ,IUnitOfWork _unitOfWork
                   ,Validator _validator
                   ,IcheckUrlExist theUrlExistTest)
        {
            repository = Guard.IsNotNull(_repository, "_repository");
            unit_of_work = Guard.IsNotNull(_unitOfWork, "_unitOfWork");
            validator = Guard.IsNotNull(_validator, "_validator");
            _testUrlExist = Guard.IsNotNull(theUrlExistTest, "theUrlExistTest");
        }

        private readonly IEntityRepository<HelpUrls> repository;
        private readonly ResponseBuilder<UpdateHelpResponse> response_Builder
            =new ResponseBuilder<UpdateHelpResponse>();

        private readonly IUnitOfWork unit_of_work;
        private readonly Validator validator;
        private readonly IcheckUrlExist _testUrlExist;
        private UpdateHelpRequest request;
    }
}