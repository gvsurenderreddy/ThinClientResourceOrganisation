using Content.Services.PlannedSupply.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove
{
    public class RemoveBreak
                : IRemoveBreak
    {
        public RemoveBreakResponse execute(BreakIdentity the_remove_break_request)
        {
            return set_request(the_remove_break_request)
                .find_break_template()
                .find_break()
                .remove_break()
                .commit()
                .build_response()
                ;
        }

        private RemoveBreak set_request(BreakIdentity the_remove_break_request)
        {
            break_request = Guard.IsNotNull(the_remove_break_request, "the_remove_break_request");

            remove_break_response_builder = new ResponseBuilder<RemoveBreakResponse>();

            return this;
        }

        private RemoveBreak find_break_template()
        {
            if (remove_break_response_builder.has_errors) return this;

            Guard.IsNotNull(break_request, "break_request");
            Guard.IsNotNull(break_template_repository, "break_template_repository");

            break_template = break_template_repository
                                        .Entities
                                        .Single(sbt => sbt.id == break_request.template_id)
                                        ;

            return this;
        }

        private RemoveBreak find_break()
        {
            if (remove_break_response_builder.has_errors) return this;

            Guard.IsNotNull(break_request, "break_request");
            Guard.IsNotNull(break_template, "break_template");

            break_to_be_deleted = break_template
                                            .all_breaks
                                            .Single(sb => sb.id == break_request.break_id)
                                            ;

            return this;
        }

        private RemoveBreak remove_break()
        {
            if (remove_break_response_builder.has_errors) return this;

            Guard.IsNotNull(break_template, "break_template");
            Guard.IsNotNull(break_to_be_deleted, "break_to_be_deleted");

            break_template.all_breaks.Remove(break_to_be_deleted);

            break_template_repository.remove(break_to_be_deleted);

            return this;
        }

        private RemoveBreak commit()
        {
            if (remove_break_response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private RemoveBreakResponse build_response()
        {
            if (remove_break_response_builder.has_errors == false)
            {
                remove_break_response_builder.add_message(ConfirmationMessages.confirmation_04_0035);
            }

            return remove_break_response_builder.build();
        }

        public RemoveBreak ( IEntityRepository<BreakTemplate> the_break_template_repository,
                             IUnitOfWork the_unit_of_work
                           )
        {
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly IEntityRepository<BreakTemplate> break_template_repository;
        private readonly IUnitOfWork unit_of_work;
        private ResponseBuilder<RemoveBreakResponse> remove_break_response_builder;
        private BreakIdentity break_request;
        private BreakTemplate break_template;
        private Breaks.Break break_to_be_deleted;
    }
}