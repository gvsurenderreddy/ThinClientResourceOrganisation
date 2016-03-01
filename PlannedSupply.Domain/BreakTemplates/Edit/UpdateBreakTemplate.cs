using Content.Services.PlannedSupply.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Validator;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit
{
    public class UpdateBreakTemplate
                        : IUpdateBreakTemplate
    {
        public UpdateBreakTemplateResponse execute(UpdateBreakTemplateRequest the_update_shift_break_template_request)
        {
            return this
                .set_request(the_update_shift_break_template_request)
                .sanitize_request()
                .find_shift_break_template()
                .validate_request()
                .update_shift_break_template()
                .commit()
                .build_response()
                ;
        }

        private UpdateBreakTemplate set_request(UpdateBreakTemplateRequest the_update_shift_break_template_request)
        {
            _update_shift_break_template_request = Guard.IsNotNull(the_update_shift_break_template_request,
                                                                   "the_update_shift_break_template_request"
                                                                  );

            _update_shift_break_template_response_builder = new ResponseBuilder<BreakTemplateIdentity, UpdateBreakTemplateResponse>();
            _update_shift_break_template_response_builder
                    .set_response(new BreakTemplateIdentity
                                        {
                                            template_id = _update_shift_break_template_request.template_id
                                        }
                    );

            return this;
        }

        private UpdateBreakTemplate sanitize_request()
        {
            if (_update_shift_break_template_response_builder.has_errors) return this;

            Guard.IsNotNull(_update_shift_break_template_request, "_update_shift_break_template_request");

            _update_shift_break_template_request = new UpdateBreakTemplateRequest
            {
                template_id = _update_shift_break_template_request
                                    .template_id,
                template_name = _update_shift_break_template_request
                                    .template_name
                                    .normalise_for_persistence(),
                is_hidden = _update_shift_break_template_request.is_hidden
            };

            return this;
        }

        private UpdateBreakTemplate find_shift_break_template()
        {
            if (_update_shift_break_template_response_builder.has_errors) return this;

            Guard.IsNotNull(_update_shift_break_template_request, "_update_shift_break_template_request");
            Guard.IsNotNull(_shift_break_template_repository, "_shift_break_template_repository");

            _shift_break_template_to_be_updated = _shift_break_template_repository
                                                        .Entities
                                                        .Single(sbt => sbt.id == _update_shift_break_template_request.template_id)
                                                        ;

            return this;
        }

        private UpdateBreakTemplate validate_request()
        {
            if (_update_shift_break_template_response_builder.has_errors) return this;

            Guard.IsNotNull(_update_shift_break_template_request, "_update_shift_break_template_request");
            Guard.IsNotNull(_shift_break_template_repository, "_shift_break_template_repository");
            Guard.IsNotNull(_shift_break_template_validator, "_shift_break_template_validator");

            if (has_validation_errors())
            {
                _update_shift_break_template_response_builder.add_errors(_validation_errors);
            }

            return this;
        }

        private UpdateBreakTemplate update_shift_break_template()
        {
            if (_update_shift_break_template_response_builder.has_errors) return this;

            Guard.IsNotNull(_update_shift_break_template_request, "_update_shift_break_template_request");
            Guard.IsNotNull(_shift_break_template_to_be_updated, "_shift_break_template_to_be_updated");

            _shift_break_template_to_be_updated.template_name = _update_shift_break_template_request.template_name;
            _shift_break_template_to_be_updated.is_hidden = _update_shift_break_template_request.is_hidden;

            return this;
        }

        private UpdateBreakTemplate commit()
        {
            if (_update_shift_break_template_response_builder.has_errors) return this;

            _unit_of_work.Commit();

            return this;
        }

        private UpdateBreakTemplateResponse build_response()
        {
            if (_update_shift_break_template_response_builder.has_errors)
            {
                _update_shift_break_template_response_builder.add_errors(new List<string>
                {
                    WarningMessages.warning_03_0024
                });
            }
            else
            {
                _update_shift_break_template_response_builder.add_message(ConfirmationMessages.confirmation_04_0030);
                _update_shift_break_template_response_builder
                        .set_response(new BreakTemplateIdentity
                                            {
                                                template_id = _shift_break_template_to_be_updated.id
                                            }
                        );
            }

            return _update_shift_break_template_response_builder.build();
        }

        private bool has_validation_errors()
        {
            BreakTemplate shift_break_template = _shift_break_template_repository
                                                            .Entities.SingleOrDefault(
                                                                sbt =>
                                                                    sbt.template_name.Equals(_update_shift_break_template_request.template_name,
                                                                        StringComparison.InvariantCultureIgnoreCase) && sbt.id != _shift_break_template_to_be_updated.id);

            bool has_a_duplicate_shift_break_template_exist_with_this_name = shift_break_template != null;

            _validation_errors = _shift_break_template_validator
                                        .validate_shift_break_template_name(_update_shift_break_template_request.template_name,
                                                                            has_a_duplicate_shift_break_template_exist_with_this_name
                                                                          )
                                        ;

            return _validation_errors.Any();
        }

        public UpdateBreakTemplate(IEntityRepository<BreakTemplate> the_shift_break_template_repository,
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

        private UpdateBreakTemplateRequest _update_shift_break_template_request;
        private BreakTemplate _shift_break_template_to_be_updated;
        private IEnumerable<ResponseMessage> _validation_errors;

        private ResponseBuilder<BreakTemplateIdentity, UpdateBreakTemplateResponse>
            _update_shift_break_template_response_builder;
    }
}