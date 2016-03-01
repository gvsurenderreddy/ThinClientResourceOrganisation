using System;
using Content.Services.PlannedSupply.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove
{
    public class RemoveBreakTemplate
                        : IRemoveBreakTemplate
    {
        public RemoveBreakTemplateResponse execute(BreakTemplateIdentity the_remove_shift_break_template_request)
        {
            return this
                .set_request(the_remove_shift_break_template_request)
                .find_shift_break_template()
                .remove_shift_break_template()
                .build_response()
                ;
        }

        private RemoveBreakTemplate set_request(BreakTemplateIdentity the_remove_shift_break_template_request)
        {
            _remove_shift_break_template_request = Guard.IsNotNull(the_remove_shift_break_template_request,
                                                                   "the_remove_shift_break_template_request"
                                                                  );

            _remove_shift_break_template_response_builder = new ResponseBuilder<RemoveBreakTemplateResponse>();

            return this;
        }

        private RemoveBreakTemplate find_shift_break_template()
        {
            if (_remove_shift_break_template_response_builder.has_errors) return this;

            Guard.IsNotNull(_remove_shift_break_template_request, "_remove_shift_break_template_request");
            Guard.IsNotNull(_shift_break_template_repository, "_shift_break_template_repository");

            _shift_break_template_to_be_removed = _shift_break_template_repository
                                                        .Entities
                                                        .Single(sbt => sbt.id == _remove_shift_break_template_request.template_id)
                                                        ;

            return this;
        }

        private RemoveBreakTemplate remove_shift_break_template()
        {
            if (_remove_shift_break_template_response_builder.has_errors) return this;

            Guard.IsNotNull(_shift_break_template_repository, "_shift_break_template_repository");
            Guard.IsNotNull(_shift_break_template_to_be_removed, "_shift_break_template_to_be_removed");

            try
            {
                _shift_break_template_repository
                    .remove( _shift_break_template_to_be_removed )
                    ;

                _unit_of_work.Commit();

                _remove_shift_break_template_response_builder.add_message( ConfirmationMessages.confirmation_04_0031 );
            }
            catch (Exception)
            {
                // If there is an exception thrown we are assuming that it is a Referential 
                // integrity exception so we fail safe and set to the entity to hidden and 
                // report the error.
                //
                // If an exception is thrown in here then we expect the standard internal 
                // error handler to catch this.  At the time of writing
                // this we do not have the standard internal error handler set up so this
                // is a little risky but I do not want to litter the code with 
                // scaffolding that will have to take out latter.

                _shift_break_template_to_be_removed.is_hidden = true;
                _shift_break_template_repository.Update( _shift_break_template_to_be_removed );
                _unit_of_work.Commit();

                _remove_shift_break_template_response_builder.add_error( WarningMessages.warning_03_0032 );
            }

            return this;
        }

        private RemoveBreakTemplateResponse build_response()
        {
            return _remove_shift_break_template_response_builder.build();
        }

        public RemoveBreakTemplate(IEntityRepository<BreakTemplate> the_shift_break_template_repository,
                                        IUnitOfWork the_unit_of_work
                                       )
        {
            _shift_break_template_repository = Guard.IsNotNull(the_shift_break_template_repository,
                                                               "the_shift_break_template_repository"
                                                              );
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly IEntityRepository<BreakTemplate> _shift_break_template_repository;
        private readonly IUnitOfWork _unit_of_work;

        private ResponseBuilder<RemoveBreakTemplateResponse> _remove_shift_break_template_response_builder;
        private BreakTemplateIdentity _remove_shift_break_template_request;
        private BreakTemplate _shift_break_template_to_be_removed;
    }
}