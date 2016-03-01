using Content.Services.PlannedSupply.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Validator;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.New
{
    public class NewBreakTemplate
                    : INewBreakTemplate
    {
        public NewBreakTemplateResponse execute(NewBreakTemplateRequest the_new_shift_break_remplate_request)
        {
            return this
                .set_request(the_new_shift_break_remplate_request)
                .sanitize_request()
                .validate_request()
                .create_new_shift_break_template()
                .commit()
                .build_response();
        }

        private NewBreakTemplate set_request(NewBreakTemplateRequest the_new_shift_break_remplate_request)
        {
            _new_shift_break_template_request = Guard.IsNotNull(the_new_shift_break_remplate_request,
                                                                "the_new_shift_break_remplate_request"
                                                               );

            _response_builder = new ResponseBuilder<BreakTemplateIdentity, NewBreakTemplateResponse>();
            _response_builder
                .set_response(new BreakTemplateIdentity
                {
                    template_id = Null.Id
                });

            return this;
        }

        private NewBreakTemplate sanitize_request()
        {
            if (_response_builder.has_errors) return this;

            Guard.IsNotNull(_new_shift_break_template_request, "_new_shift_break_template_request");

            _new_shift_break_template_request = new NewBreakTemplateRequest
            {
                template_name = _new_shift_break_template_request
                                                .template_name
                                                .normalise_for_persistence(),
                                is_hidden = _new_shift_break_template_request.is_hidden
            };

            return this;
        }

        private NewBreakTemplate validate_request()
        {
            if (_response_builder.has_errors) return this;

            Guard.IsNotNull(_new_shift_break_template_request, "_new_shift_break_template_request");
            Guard.IsNotNull(_shift_break_template_repository, "_shift_break_template_repository");
            Guard.IsNotNull(_shift_break_template_validator, "_shift_break_template_validator");

            if (has_validation_errors())
            {
                _response_builder.add_errors(_validation_errors);
            }

            return this;
        }

        private NewBreakTemplate create_new_shift_break_template()
        {
            if (_response_builder.has_errors) return this;

            Guard.IsNotNull(_new_shift_break_template_request, "_new_shift_break_template_request");
            Guard.IsNotNull(_shift_break_template_repository, "_shift_break_template_repository");

            _new_shift_break_template = new BreakTemplate
            {
                template_name = _new_shift_break_template_request.template_name,
                is_hidden = _new_shift_break_template_request.is_hidden
            };

            _shift_break_template_repository
                .add(_new_shift_break_template)
                ;

            return this;
        }

        private NewBreakTemplate commit()
        {
            if (_response_builder.has_errors) return this;

            _unit_of_work.Commit();

            return this;
        }

        private NewBreakTemplateResponse build_response()
        {
            if (_response_builder.has_errors)
            {
                _response_builder.add_errors(new List<string> { WarningMessages.warning_03_0023 });
            }
            else
            {
                _response_builder.add_message(ConfirmationMessages.confirmation_04_0029);
                _response_builder.set_response(new BreakTemplateIdentity { template_id = _new_shift_break_template.id });
            }

            return _response_builder.build();
        }

        private bool has_validation_errors()
        {
            BreakTemplate shift_break_template = _shift_break_template_repository
                                                            .Entities.SingleOrDefault(
                                                                sbt =>
                                                                    sbt.template_name.Equals(_new_shift_break_template_request.template_name,
                                                                        StringComparison.InvariantCultureIgnoreCase));

            bool has_a_duplicate_shift_break_template_exist_with_this_name = shift_break_template != null;

            _validation_errors = _shift_break_template_validator
                                        .validate_shift_break_template_name(_new_shift_break_template_request.template_name,
                                                                            has_a_duplicate_shift_break_template_exist_with_this_name
                                                                          )
                                        ;

            return _validation_errors.Any();
        }

        public NewBreakTemplate(IEntityRepository<BreakTemplate> the_shift_break_template_repository,
                                        BreakTemplateValidator the_shift_break_template_validator,
                                        IUnitOfWork the_unit_of_work
                                    )
        {
            _shift_break_template_repository = Guard.IsNotNull(the_shift_break_template_repository,
                                                                "the_shift_break_template_repository"
                                                              );
            _shift_break_template_validator = Guard.IsNotNull(the_shift_break_template_validator,
                                                                "the_shift_break_template_validator"
                                                             );
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly IEntityRepository<BreakTemplate> _shift_break_template_repository;
        private readonly BreakTemplateValidator _shift_break_template_validator;
        private readonly IUnitOfWork _unit_of_work;

        private NewBreakTemplateRequest _new_shift_break_template_request;
        private BreakTemplate _new_shift_break_template;
        private IEnumerable<ResponseMessage> _validation_errors;
        private ResponseBuilder<BreakTemplateIdentity, NewBreakTemplateResponse> _response_builder;
    }
}